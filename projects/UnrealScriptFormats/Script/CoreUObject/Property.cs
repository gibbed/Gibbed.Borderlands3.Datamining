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
    public class Property : Field
    {
        #region Fields
        private int _ArraySize;
        private ulong _PropertyFlags;
        private Name _RepNotifyFunc;
        #endregion

        #region Properties
        public int ArraySize
        {
            get => this._ArraySize;
            set => this._ArraySize = value;
        }

        public ulong PropertyFlags
        {
            get => this._PropertyFlags;
            set => this._PropertyFlags = value;
        }

        public Name RepNotifyFunc
        {
            get => this._RepNotifyFunc;
            set => this._RepNotifyFunc = value;
        }
        #endregion

        public override void Serialize(IUnrealSerializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(ref this._ArraySize);
            serializer.Serialize(ref this._PropertyFlags);
            serializer.Serialize(ref this._RepNotifyFunc);
        }
    }
}
