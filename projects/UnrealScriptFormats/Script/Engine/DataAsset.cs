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

namespace Script.Engine
{
    public class DataAsset : CoreUObject.Object
    {
        private ObjectReference<CoreUObject.Class> _NativeClass;

        public ObjectReference<CoreUObject.Class> NativeClass
        {
            get => this._NativeClass;
            set => this._NativeClass = value;
        }

        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "NativeClass")
            {
                serializer.Serialize(ref this._NativeClass);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
