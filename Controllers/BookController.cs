// using Microsoft.AspNetCore.Mvc;

// namespace BookStoreBackend.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class BookController : ControllerBase
// {
// private readonly HttpClient _httpClient;

//     public BookController(IHttpClientFactory httpClientFactory)
//     {
//         _httpClient = httpClientFactory.CreateClient();
//         _httpClient.BaseAddress = new Uri("http://localhost:5000/graphql"); // Point to your GraphQL API
//     }

//     // GET: api/graphqlproxy/books
//     [HttpGet("books")]
//     public async Task<IActionResult> GetBooks()
//     {
//         var query = new
//         {
//             query = @"
//                 query {
//                   getBooks {
//                     id
//                     title
//                     authorId
//                   }
//                 }"
//         };

//         var response = await SendGraphQLRequest(query);
//         return Ok(response);
//     }

//     // POST: api/graphqlproxy/books
//     [HttpPost("books")]
//     public async Task<IActionResult> AddBook([FromBody] AddBookDto bookDto)
//     {
//         var query = new
//         {
//             query = @"
//                 mutation ($title: String!, $authorId: Int!) {
//                   addBook(title: $title, authorId: $authorId) {
//                     id
//                     title
//                     authorId
//                   }
//                 }",
//             variables = new
//             {
//                 title = bookDto.Title,
//                 authorId = bookDto.AuthorId
//             }
//         };

//         var response = await SendGraphQLRequest(query);
//         return Ok(response);
//     }

//     private async Task<object> SendGraphQLRequest(object query)
//     {
//         var requestContent = new StringContent(
//             JsonSerializer.Serialize(query),
//             Encoding.UTF8,
//             "application/json"
//         );

//         var response = await _httpClient.PostAsync("", requestContent);

//         response.EnsureSuccessStatusCode();
//         var responseContent = await response.Content.ReadAsStringAsync();

//         return JsonSerializer.Deserialize<object>(responseContent);
//     }
// }
// }
