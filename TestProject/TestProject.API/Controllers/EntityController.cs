using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess;
using TestProject.DataAccess.Entities;

namespace TestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<EntityController> _logger;

        public EntityController(ApplicationDbContext applicationDbContext, ILogger<EntityController> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetAsync()
        {
            return await _applicationDbContext.Entities.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync(Entity entity)
        {
            entity.EntityId = 0;
            _applicationDbContext.Entities.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity.EntityId;
        }
    }
}