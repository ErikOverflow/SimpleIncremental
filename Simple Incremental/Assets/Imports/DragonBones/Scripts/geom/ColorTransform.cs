/**
 * The MIT License (MIT)
 *
 * Copyright (c) 2012-2017 DragonBones team and other contributors
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 * the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
﻿namespace DragonBones
{
    /// <internal/>
    /// <private/>
    public class ColorTransform
    {
        public float alphaMultiplier = 1.0f;
        public float redMultiplier = 1.0f;
        public float greenMultiplier = 1.0f;
        public float blueMultiplier = 1.0f;
        public int alphaOffset = 0;
        public int redOffset = 0;
        public int greenOffset = 0;
        public int blueOffset = 0;

        public ColorTransform()
        {
        }

        public void CopyFrom(ColorTransform value)
        {
            this.alphaMultiplier = value.alphaMultiplier;
            this.redMultiplier = value.redMultiplier;
            this.greenMultiplier = value.greenMultiplier;
            this.blueMultiplier = value.blueMultiplier;
            this.alphaOffset = value.alphaOffset;
            this.redOffset = value.redOffset;
            this.redOffset = value.redOffset;
            this.greenOffset = value.blueOffset;
        }

        public void Identity()
        {
            this.alphaMultiplier = this.redMultiplier = this.greenMultiplier = this.blueMultiplier = 1.0f;
            this.alphaOffset = this.redOffset = this.greenOffset = this.blueOffset = 0;
        }
    }
}
