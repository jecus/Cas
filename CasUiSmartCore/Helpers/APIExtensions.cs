using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CAS.UI.Helpers
{
	public static class APIExtensions
	{
		public static async Task<ApiResult<TResult>> GetJsonAsync<TResult>(this HttpClient client, string requestUri)
		{
			var res = await client.GetAsync(requestUri);
			var content = await res.Content.ReadAsStringAsync();

			return new ApiResult<TResult>
			{
				IsSuccessful = res.IsSuccessStatusCode,
				StatusCode = res.StatusCode,
				Data = res.IsSuccessStatusCode ? JsonConvert.DeserializeObject<TResult>(content) : default(TResult),
				Error = res.IsSuccessStatusCode ? null : (content ?? res.ReasonPhrase)
			};
		}

		public static async Task<ApiResult<TResult>> SendJsonAsync<TModel, TResult>(this HttpClient client, HttpMethod httpMethod, string requestUri, TModel model)
		{
			var json = JsonConvert.SerializeObject(model);
			var message = new HttpRequestMessage(httpMethod, requestUri)
			{
				Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Octet)
			};
			var res = await client.SendAsync(message);
			var content = await res.Content.ReadAsStringAsync();

			return new ApiResult<TResult>
			{
				IsSuccessful = res.IsSuccessStatusCode,
				StatusCode = res.StatusCode,
				Data = res.IsSuccessStatusCode
					? (string.IsNullOrWhiteSpace(content) ? default(TResult) : JsonConvert.DeserializeObject<TResult>(content))
					: default(TResult),
				Error = res.IsSuccessStatusCode ? null : (content ?? res.ReasonPhrase)
			};
		}
	}


	public class ApiResult<TView>
	{
		/// <summary>
		/// Данные
		/// </summary>
		public TView Data { get; set; }

		/// <summary>
		/// Флаг успешности
		/// </summary>
		public bool IsSuccessful { get; set; }

		/// <summary>
		/// Код ошибки
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		public string Error { get; set; }
	}
}