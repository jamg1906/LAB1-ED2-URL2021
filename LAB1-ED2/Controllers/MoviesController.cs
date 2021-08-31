using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LAB1_ED2.Helpers;
using System.Text.Json;
using LAB1_ED2.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LAB1_ED2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/<MoviesController>/inorder
        [HttpGet("{traversal}")]
        public IEnumerable<Movies> Get(string traversal)
        {
            try
            {
                //ACÁ HAY QUE ARREGLAR LOS RECORRIDOS Y QUE DEVUELVAN UN STRING.
                if (traversal == "inorden")
                {
                    var inorder = Storage.Instance.arbolito.ConvertirALista();
                    return default;
                }
                if (traversal == "preorden")
                {
                    var preorder = Storage.Instance.arbolito.ConvertirALista();
                    return default;
                }
                if (traversal == "postorden")
                {
                    var postorder = Storage.Instance.arbolito.ConvertirALista();
                    return default;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "nada";
        }


        // POST api/<MoviesController>

        [HttpPost]
        public ActionResult Post([FromBody] JsonElement jsonobj)
        {
            try
            {
                JsonElement jsonprop = jsonobj.GetProperty("order");
                int degree = jsonprop.GetInt32();
                if (degree < 3)
                {
                    return StatusCode(500);
                }
                //Esta línea debería inicializar el árbol, falta cambiar delegado.
                Lab01.Models.CompararCon<Movies> CC = new Lab01.Models.CompararCon<Movies>(Movies.Comparison);
                Storage.Instance.arbolito = new Lab01.Models.arbolB<Movies>(degree, CC);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("populate")]
        public ActionResult LeerJson([FromForm] IFormFile file)
        {
            try
            {
                List<Movies> moviesList;
                using (var reserved_memory = new MemoryStream())
                {
                    file.CopyToAsync(reserved_memory);
                    string json_text = Encoding.ASCII.GetString(reserved_memory.ToArray());

                    JsonSerializerOptions name_rule = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreNullValues = true };
                    moviesList = JsonSerializer.Deserialize<List<Movies>>(json_text, name_rule);
                }

                if (moviesList != null)
                {
                    for (int i = 0; i < moviesList.Count; i++)
                    {
                        Movies Temp = moviesList[i];
                        Temp.id = Temp.title + "-" + Convert.ToDateTime(Temp.releaseDate).Year;
                        Storage.Instance.arbolito.Insertar(Temp);
                    }
                    return Ok();
                }
                return StatusCode(500);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
