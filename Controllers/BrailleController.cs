using Microsoft.AspNetCore.Mvc;
using System;

namespace BrailleWinAPI.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class DotPrintController : ControllerBase
    {
        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPrint = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPrint += ". ";
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }

        [HttpGet("circle/{radius}/{resolution}")]
        public IActionResult GetCircle(int radius, int resolution)
        {
            string dotPrint = "";
            double step = 2 * Math.PI / resolution;
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double distance = Math.Sqrt(x * x + y * y);
                    if (Math.Abs(distance - radius) < step / 2)
                    {
                        dotPrint += ".";
                    }
                    else
                    {
                        dotPrint += " ";
                    }
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }
        [HttpGet("righttriangle/{width}")]
        public IActionResult GetRTriangle(int width)
        {
            string dotPrint = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    dotPrint += ".";
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }

        [HttpGet("lefttriangle/{width}")]
        public IActionResult GetLTriangle(int width)
        {
            string dotPrint = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    dotPrint += ".";
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }

    }


}
