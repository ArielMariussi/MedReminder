using Med.Core.Handlers;
using Med.Core.Models;
using Med.Core.Requests.Medicines;
using Med.Core.Responses;
using System.Net.Http.Json;

namespace Med.Web.Handlers;

public class MedicineHandler(IHttpClientFactory httpClientFactory) : IMedicineHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    public async Task<Response<Medicine>> CreateAsync(CreateMedicineRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/medicines", request);

        if (!result.IsSuccessStatusCode)
            return Response<Medicine>.Fail("Unable to create medicine");

        return await result.Content.ReadFromJsonAsync<Response<Medicine>>()
            ?? Response<Medicine>.Fail("Unexpected error");

    }

    public async  Task<Response<bool>> DeleteAsync(DeleteMedicineRequest request)
    {
        var result = await _client.DeleteAsync($"v1/medicines/{request.Id}");

        if (!result.IsSuccessStatusCode)
            return Response<bool>.Fail("Error deleting medicine");

        return await result.Content.ReadFromJsonAsync<Response<bool>>()
            ?? Response<bool>.Fail("Unexpected error");

    }

    public async Task<Response<Medicine?>> GetByIdAsync(GetMedicineByIdRequest request)
    {
        return await _client.GetFromJsonAsync<Response<Medicine?>>($"v1/medicines/{request.Id}")
             ?? Response<Medicine?>.Fail("Medicine not found");
    }

    public async  Task<Response<IEnumerable<Medicine>>> GetByUserAsync(GetMedicinesByUserRequest request)
    {
        try
        {
            var response = await _client.GetAsync("v1/medicines/user");
            if (!response.IsSuccessStatusCode)
                return Response<IEnumerable<Medicine>>.Fail("Unauthorized");
            return await response.Content.ReadFromJsonAsync<Response<IEnumerable<Medicine>>>()
                   ?? Response<IEnumerable<Medicine>>.Fail("Error loading");
        }
        catch
        {
            return Response<IEnumerable<Medicine>>.Fail("Error loading medicines");
        }
    }

    public async  Task<Response<Medicine>> MarkAsTakenAsync(MarkMedicineAsTakenRequest request)
    {
        var result = await _client.PostAsJsonAsync($"v1/medicines/taken/{request.Id}", request);

        if (!result.IsSuccessStatusCode)
            return Response<Medicine>.Fail("Error marking medicine as taken");

        return await result.Content.ReadFromJsonAsync<Response<Medicine>>()
            ?? Response<Medicine>.Fail("Unexpected error");
    }

    public async Task<Response<IEnumerable<Medicine>>> SearchByNameAsync(SearchMedicineByNameRequest request)
    {
        return await _client.GetFromJsonAsync<Response<IEnumerable<Medicine>>>($"v1/medicines/search?name={request.Name}")
            ?? Response<IEnumerable<Medicine>>.Fail("Error searching");
    }
}
