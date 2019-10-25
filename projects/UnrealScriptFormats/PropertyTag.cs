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

namespace UnrealScriptFormats
{
    public struct PropertyTag : IUnrealSerializable
    {
        public Name Type;
        public byte BoolValue;
        public Name Name;
        public Name StructName;
        public Name EnumName;
        public Name InnerType;
        public Name ValueType;
        public int Size;
        public int ArrayIndex;
        public long SizeOffset;
        public Guid StructGuid;
        public Guid? PropertyGuid;

        public void Serialize(IUnrealSerializer serializer)
        {
            serializer.Serialize(ref this.Name);

            if (this.Name == "None")
            {
                return;
            }

            serializer.Serialize(ref this.Type);
            serializer.Serialize(ref this.Size);
            serializer.Serialize(ref this.ArrayIndex);

            if (this.Type == "StructProperty")
            {
                serializer.Serialize(ref this.StructName);
                serializer.Serialize(ref this.StructGuid);
            }
            else if (this.Type == "BoolProperty")
            {
                serializer.Serialize(ref this.BoolValue);
            }
            else if (this.Type == "ByteProperty" || this.Type == "EnumProperty")
            {
                serializer.Serialize(ref this.EnumName);
            }
            else if (this.Type == "ArrayProperty")
            {
                serializer.Serialize(ref this.InnerType);
            }
            else if (this.Type == "SetProperty")
            {
                serializer.Serialize(ref this.InnerType);
            }
            else if (this.Type == "MapProperty")
            {
                serializer.Serialize(ref this.InnerType);
                serializer.Serialize(ref this.ValueType);
            }

            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                byte hasPropertyGuid = 0;
                serializer.Serialize(ref hasPropertyGuid);
                if (hasPropertyGuid == 0)
                {
                    this.PropertyGuid = null;
                }
                else
                {
                    Guid propertyGuid = Guid.Empty;
                    serializer.Serialize(ref propertyGuid);
                    this.PropertyGuid = propertyGuid;
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public override string ToString()
        {
            return $"{this.Name} : {this.Type}";
        }
    }
}
