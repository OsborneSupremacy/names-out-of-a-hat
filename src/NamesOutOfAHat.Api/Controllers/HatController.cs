﻿using Microsoft.AspNetCore.Mvc;
using NamesOutOfAHat.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NamesOutOfAHat.Service;
using NamesOutOfAHat.Interface;
using NamesOutOfAHat.Models;
using System.Linq;

namespace NamesOutOfAHat.Api.Controllers
{
    public class HatController : Controller
    {
        private readonly ValidationService _validationService;

        public HatController(ValidationService validationService)
        {
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        [HttpPost]
        [Route("api/hat/validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] IList<Giver> people)
        {
            var response = new ResponseModel();

            (response.Success, response.Errors) = _validationService
                .Validate(people.Select(x => x as IGiver)
                .ToList());

            if (!response.Success)
                return new BadRequestObjectResult(response);

            return new OkObjectResult(response);
        }
    }
}