using AlunosAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosRepository _alunosRepository;

        public AlunosController(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }
    }
}
