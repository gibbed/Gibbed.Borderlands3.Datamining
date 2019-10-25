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

namespace Script.GbxInventory
{
    public class RuntimeGenericPartListData : PropertyBag
    {
        #region Fields
        private bool _IsEnabled;
        private TaggedArray<GbxGameSystemCore.WeightedActorPartData> _PartList;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get => this._IsEnabled;
            set => this._IsEnabled = value;
        }

        public TaggedArray<GbxGameSystemCore.WeightedActorPartData> PartList
        {
            get => this._PartList;
            set => this._PartList = value;
        }
        #endregion

        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "bEnabled")
            {
                serializer.Serialize(ref tag, ref this._IsEnabled);
                return true;
            }
            else if (tag.Name == "PartList")
            {
                serializer.Serialize(ref this._PartList);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
