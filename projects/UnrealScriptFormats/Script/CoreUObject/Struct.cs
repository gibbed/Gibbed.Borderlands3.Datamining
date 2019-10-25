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
    public class Struct : Field
    {
        #region Fields
        private ObjectReference _SuperStruct;
        private ObjectReference[] _Children;
        private int _BytecodeBufferSize;
        private byte[] _SerializedScriptBytes;
        #endregion

        #region Properties
        public ObjectReference SuperStruct
        {
            get { return this._SuperStruct; }
            set { this._SuperStruct = value; }
        }

        public ObjectReference[] Children
        {
            get { return this._Children; }
            set { this._Children = value; }
        }

        public int BytecodeBufferSize
        {
            get { return this._BytecodeBufferSize; }
            set { this._BytecodeBufferSize = value; }
        }

        public byte[] SerializedScriptBytes
        {
            get { return this._SerializedScriptBytes; }
            set { this._SerializedScriptBytes = value; }
        }
        #endregion

        public override void Serialize(IUnrealSerializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(ref this._SuperStruct);
            serializer.Serialize(ref this._Children);
            this.SerializeScript(serializer);
        }

        protected virtual void SerializeScript(IUnrealSerializer serializer)
        {
            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                int bytecodeBufferSize = 0;
                serializer.Serialize(ref bytecodeBufferSize);
                int serializedScriptSize = 0;
                serializer.Serialize(ref serializedScriptSize);

                var serializedScriptBytes = new byte[serializedScriptSize];
                serializer.Serialize(serializedScriptBytes, 0, serializedScriptBytes.Length);

                this._BytecodeBufferSize = bytecodeBufferSize;
                this._SerializedScriptBytes = serializedScriptBytes;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
