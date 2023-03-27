using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.CognitiveServices.Speech;


namespace BrailleWinAPI.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class DotPrintController : ControllerBase
    {

        //To print rectangle
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
        // to print circle
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

        //To print  right align triangle
        [HttpGet("righttriangle/{width}")]
        public IActionResult GetRTriangle(int width)
        {
            string dotPrint = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width - i - 1; j++)
                {
                    dotPrint += " ";
                }
                for (int j = 0; j <= i; j++)
                {
                    dotPrint += ".";
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }


        //To print Left align triangle
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

        //To print piramide
        [HttpGet("piramide/{rows}")]
        public IActionResult GetPiramide(int rows)
        {
            string dotPrint = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    dotPrint += " ";
                }
                for (int j = 0; j <= i * 2; j++)
                {
                    dotPrint += ".";
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }

        //To print diamond
        [HttpGet("diamond/{rows}")]
        public IActionResult GetDiamond(int rows)
        {
            string dotPrint = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    dotPrint += " ";
                }
                for (int j = 0; j <= i * 2; j++)
                {
                    dotPrint += ".";
                }
                dotPrint += "\n";
            }
            for (int i = rows - 1; i >= 1; --i)
            {
                for (int j = 1; j <= rows - i; ++j)
                {
                    dotPrint += " ";
                }
                for (int j = 1; j <= 2 * i - 1; ++j)
                {
                    dotPrint += ".";
                }
                dotPrint += "\n";
            }
            return Ok(dotPrint);
        }

        //To print convert in to braille
        [HttpGet("brailletext/{text}")]
        public IActionResult GetBraille(string text)
        {
            string braille = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                {
                    braille += braille_a_to_z[c - 'a'];
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    braille += braille_A_to_Z[c - 'A'];
                }
                else if (c >= '0' && c <= '9')
                {
                    braille += braille_0_to_9[c - '0'];
                }
                else
                {
                    braille += " ";
                }
            }
            return Ok(braille);
        }

        private static string[] braille_a_to_z = new string[]
        {
            "⠁", "⠃", "⠉", "⠙", "⠑", "⠋", "⠛", "⠓", "⠊", "⠚",
            "⠅", "⠇", "⠍", "⠝", "⠕", "⠏", "⠟", "⠗", "⠎", "⠞",
            "⠥", "⠧", "⠺", "⠭", "⠽", "⠵"
        };

        private static string[] braille_A_to_Z = new string[]
        {
            "⠠⠁", "⠠⠃", "⠠⠉", "⠠⠙", "⠠⠑", "⠠⠋", "⠠⠛", "⠠⠓", "⠠⠊", "⠠⠚",
            "⠠⠅", "⠠⠇", "⠠⠍", "⠠⠝", "⠠⠕", "⠠⠏", "⠠⠟", "⠠⠗", "⠠⠎", "⠠⠞",
            "⠠⠥", "⠠⠧", "⠠⠺", "⠠⠭", "⠠⠽", "⠠⠵"
        };

        private static string[] braille_0_to_9 = new string[]
        {
            "⠚", "⠁⠃", "⠉⠙", "⠑⠋", "⠍⠝", "⠕⠏", "⠋⠟", "⠛⠗", "⠓⠎", "⠊⠞"
        };

        //To recognize voice
        [HttpGet("voicerecognize/{voice}")]
        public async Task<string> Get()
        {
            // Configure the subscription key and region for the Speech Service
            string subscriptionKey = "<your-subscription-key>";
            string region = "<your-region>";

            // Create a SpeechRecognizer object
            var config = SpeechConfig.FromSubscription(subscriptionKey, region);
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Start recognition
                var result = await recognizer.RecognizeOnceAsync();

                // Check the result
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    // Return the recognized text
                    return result.Text;
                }
                else
                {
                    return "Recognition failed.";
                }
            }
        }

    }
}
