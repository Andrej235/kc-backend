using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class ObjectController
    {
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return NotFound();

            await deleteService.Delete(x => x.Id == id);
            return NoContent();
        }
    }
}
