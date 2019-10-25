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
using UnrealScriptFormats;

namespace Script.CoreUObject
{
    public class Class : Struct
    {
        #region Fields
        private uint _ClassFlags;
        private ObjectReference _ClassWithin;
        private Name _ClassConfigName;
        private ObjectReference _ClassGeneratedBy;
        private bool _IsCooked;
        private ObjectReference _ClassDefaultObject;
        #endregion

        #region Properties
        public uint ClassFlags
        {
            get => this._ClassFlags;
            set => this._ClassFlags = value;
        }

        public ObjectReference ClassWithin
        {
            get => this._ClassWithin;
            set => this._ClassWithin = value;
        }

        public Name ClassConfigName
        {
            get => this._ClassConfigName;
            set => this._ClassConfigName = value;
        }

        public ObjectReference ClassGeneratedBy
        {
            get => this._ClassGeneratedBy;
            set => this._ClassGeneratedBy = value;
        }

        public bool IsCooked
        {
            get => this._IsCooked;
            set => this._IsCooked = value;
        }

        public ObjectReference ClassDefaultObject
        {
            get => this._ClassDefaultObject;
            set => this._ClassDefaultObject = value;
        }
        #endregion

        public override void Serialize(IUnrealSerializer serializer)
        {
            base.Serialize(serializer);

            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                int funcMapCount = 0;
                serializer.Serialize(ref funcMapCount);
                if (funcMapCount != 0)
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotSupportedException();
            }

            serializer.Serialize(ref this._ClassFlags);
            serializer.Serialize(ref this._ClassWithin);
            serializer.Serialize(ref this._ClassConfigName);
            serializer.Serialize(ref this._ClassGeneratedBy);

            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                int interfaceCount = 0;
                serializer.Serialize(ref interfaceCount);
                if (interfaceCount != 0)
                {
                    throw new NotImplementedException();
                }

                bool forceScriptOrder = false;
                serializer.Serialize(ref forceScriptOrder);

                Name dummy = default;
                serializer.Serialize(ref dummy);
            }
            else
            {
                throw new NotSupportedException();
            }

            serializer.Serialize(ref this._IsCooked);
            serializer.Serialize(ref this._ClassDefaultObject);
        }
    }
}
