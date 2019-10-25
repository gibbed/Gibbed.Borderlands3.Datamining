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

namespace Script.Engine
{
    public abstract class DataTable<TRow> : CoreUObject.Object
        where TRow: IUnrealSerializable, new()
    {
        private ObjectReference<CoreUObject.ScriptStruct> _RowStruct;
        private bool _StripFromClientBuilds;

        public DataTable()
        {
            this.Rows = new Dictionary<string, TRow>();
        }

        public ObjectReference<CoreUObject.ScriptStruct> RowStruct
        {
            get => this._RowStruct;
            set => this._RowStruct = value;
        }

        public bool StripFromClientBuilds
        {
            get => this._StripFromClientBuilds;
            set => this._StripFromClientBuilds = value;
        }

        public Dictionary<string, TRow> Rows { get; }

        public override void Serialize(IUnrealSerializer serializer)
        {
            base.Serialize(serializer);

            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                int count = 0;
                serializer.Serialize(ref count);

                this.Rows.Clear();
                for (int i = 0; i < count; i++)
                {
                    var rowName = new Name();
                    serializer.Serialize(ref rowName);

                    var rowValue = new TRow();
                    serializer.Serialize(ref rowValue);
                    this.Rows[rowName] = rowValue;
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "RowStruct")
            {
                serializer.Serialize(ref this._RowStruct);
                return true;
            }
            else if (tag.Name == "bStripFromClientBuilds")
            {
                serializer.Serialize(ref tag, ref this._StripFromClientBuilds);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
