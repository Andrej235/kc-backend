﻿using kc_backend.DTOs.Requests.Object;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class ObjectController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateObjectRequestDTO request)
        {
            _ = await createService.Add(createMapper.Map(request));
            return Created();
        }
    }
}
