/* Copyright (c) 2019 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using UnrealScriptFormats;

namespace Script.CoreUObject
{
    public class Function : Struct
    {
        #region Fields
        private FunctionFlags _FunctionFlags;
        private ushort _RepOffset;
        private ObjectReference _EventGraphFunction;
        private int _EventGraphCallOffset;
        #endregion

        #region Properties
        public FunctionFlags FunctionFlags
        {
            get { return this._FunctionFlags; }
            set { this._FunctionFlags = value; }
        }

        public ushort RepOffset
        {
            get { return this._RepOffset; }
            set { this._RepOffset = value; }
        }

        public ObjectReference EventGraphFunction
        {
            get { return this._EventGraphFunction; }
            set { this._EventGraphFunction = value; }
        }

        public int EventGraphCallOffset
        {
            get { return this._EventGraphCallOffset; }
            set { this._EventGraphCallOffset = value; }
        }
        #endregion

        public override void Serialize(IUnrealSerializer serializer)
        {
            base.Serialize(serializer);

            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                uint rawFunctionFlags = 0;
                serializer.Serialize(ref rawFunctionFlags);
                this._FunctionFlags = (FunctionFlags)rawFunctionFlags;
            }
            else if (serializer.Mode == UnrealSerializationMode.Saving)
            {
                var rawFunctionFlags = (uint)this._FunctionFlags;
                serializer.Serialize(ref rawFunctionFlags);
            }

            if ((this._FunctionFlags & FunctionFlags.Net) != 0)
            {
                serializer.Serialize(ref this._RepOffset);
            }

            serializer.Serialize(ref this._EventGraphFunction);
            serializer.Serialize(ref this._EventGraphCallOffset);
        }
    }
}
