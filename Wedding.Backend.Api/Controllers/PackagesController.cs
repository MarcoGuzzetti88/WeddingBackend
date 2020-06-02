using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Wedding.Backend.Api.Models;
using Wedding.Backend.BLL;
using Wedding.Backend.BLL.Generic;

namespace Wedding.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPackageRetreiver packageReader;
        private readonly IContributionHandler contributionHandler;

        public PackagesController(IHttpContextAccessor httpContextAccessor, IPackageRetreiver packageReader, IContributionHandler contributionHandler)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.packageReader = packageReader;
            this.contributionHandler = contributionHandler;
        }

        [HttpGet]
        [HttpOptions]
        [ProducesResponseType(typeof(PackageResponse), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var packages = packageReader.GetAll();

            var res = new PackageResponse
            {
                Success = true,
                Data = packages
            };

            return Ok(res);
        }

        [HttpPost("contributor")]
        [ProducesResponseType(typeof(ContributionResponse), StatusCodes.Status200OK)]
        public IActionResult Contribute([FromQuery]int Id, [FromBody] Models.ContributionModel contributePosted)
        {
            try
            {
                var contribution = contributionHandler.Contribute(Id, contributePosted.Email, contributePosted.Message, contributePosted.Contribution);

                // mandare email
            }
            catch (Exception)
            {
                return Ok(new PackageResponse { Success = false });
            }

            return Ok(new PackageResponse { Success = true });
        }
    }
}