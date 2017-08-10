using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MitchHotkeys.MiddleTier.Model.Sound
{
    public interface IPitchDetector
    {
        float DetectPitch(float[] buffer, int frames);
    }
}
