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

using System;
using System.Collections.Generic;
using UnrealScriptFormats;

namespace Script.GbxGameSystemCore
{
    public class ActorPartSetData : GbxRuntime.GbxDataAsset
    {
        #region Fields
        private ObjectReference<CoreUObject.Class> _PartDataClass;
        private ObjectReference _PartTypeEnum;
        private Name _ActorPartReplacementMode;
        private TaggedArray<ActorPartListData> _ActorPartLists;
        private TaggedArray<ActorPartListData> _OldActorPartLists;
        private Guid _Guid;
        private readonly List<Name> _ActorPartListEnumerators;
        #endregion

        public ActorPartSetData()
        {
            this._ActorPartListEnumerators = new List<Name>();
        }

        #region Properties
        public ObjectReference<CoreUObject.Class> PartDataClass
        {
            get => this._PartDataClass;
            set => this._PartDataClass = value;
        }

        public ObjectReference PartTypeEnum
        {
            get => this._PartTypeEnum;
            set => this._PartTypeEnum = value;
        }

        public Name ActorPartReplacementMode
        {
            get => this._ActorPartReplacementMode;
            set => this._ActorPartReplacementMode = value;
        }

        public TaggedArray<ActorPartListData> ActorPartLists
        {
            get => this._ActorPartLists;
            set => this._ActorPartLists = value;
        }

        public TaggedArray<ActorPartListData> OldActorPartLists
        {
            get => this._OldActorPartLists;
            set => this._OldActorPartLists = value;
        }

        public Guid Guid
        {
            get => this._Guid;
            set => this._Guid = value;
        }

        public List<Name> ActorPartListEnumerators
        {
            get => this._ActorPartListEnumerators;
        }
        #endregion

        public override void Serialize(IUnrealSerializer serializer)
        {
            base.Serialize(serializer);

            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                this._ActorPartListEnumerators.Clear();
                if (this._ActorPartLists != null)
                {
                    var actorPartListEnumerators = new List<Name>();
                    for (int i = 0; i < this._ActorPartLists.Items.Count; i++)
                    {
                        Name actorPartListEnumerator = default;
                        serializer.Serialize(ref actorPartListEnumerator);
                        actorPartListEnumerators.Add(actorPartListEnumerator);
                    }
                    this._ActorPartListEnumerators.AddRange(actorPartListEnumerators);
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "PartDataClass")
            {
                serializer.Serialize(ref this._PartDataClass);
                return true;
            }
            else if (tag.Name == "PartTypeEnum")
            {
                serializer.Serialize(ref this._PartTypeEnum);
                return true;
            }
            else if (tag.Name == "ActorPartReplacementMode")
            {
                serializer.Serialize(ref this._ActorPartReplacementMode);
                return true;
            }
            else if (tag.Name == "ActorPartLists")
            {
                serializer.Serialize(ref this._ActorPartLists);
                return true;
            }
            else if (tag.Name == "OldActorPartLists")
            {
                serializer.Serialize(ref this._OldActorPartLists);
                return true;
            }
            else if (tag.Name == "Guid")
            {
                serializer.Serialize(ref this._Guid);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
