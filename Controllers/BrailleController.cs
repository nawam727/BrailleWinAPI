using Microsoft.AspNetCore.Mvc;
using System;

namespace BrailleWinAPI.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class DotPatterController : ControllerBase
    {
        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += ". ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }

        [HttpGet("circle/{radius}/{resolution}")]
        public IActionResult GetCircle(int radius, int resolution)
        {
            string dotPattern = "";
            double step = 2 * Math.PI / resolution;
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double distance = Math.Sqrt(x * x + y * y);
                    if (Math.Abs(distance - radius) < step / 2)
                    {
                        dotPattern += ".";
                    }
                    else
                    {
                        dotPattern += " ";
                    }
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }
    }

    
}
