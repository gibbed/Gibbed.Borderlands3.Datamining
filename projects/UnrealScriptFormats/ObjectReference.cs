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

namespace UnrealScriptFormats
{
    public struct ObjectReference : IUnrealSerializable
    {
        private int _Index;

        public ObjectReference(int index)
        {
            this._Index = index;
        }

        public int RawIndex
        {
            get => this._Index;
            set => this._Index = value;
        }

        public void Serialize(IUnrealSerializer serializer)
        {
            serializer.Serialize(ref _Index);
        }

        public int ImportIndex
        {
            get
            {
                if (this._Index < 0)
                {
                    return -this._Index - 1;
                }
                return -1;
            }
        }

        public int ExportIndex
        {
            get
            {
                if (this._Index > 0)
                {
                    return this._Index - 1;
                }
                return -1;
            }
        }

        public bool IsValid
        {
            get { return this._Index != 0; }
        }

        public override string ToString()
        {
            if (this._Index < 0)
            {
                return $"Import:{-this._Index - 1}";
            }

            if (this._Index > 0)
            {
                return $"Export:{this._Index - 1}";
            }

            return "None";
        }
    }

    public struct ObjectReference<T> : IUnrealSerializable
        where T: IUnrealSerializable
    {
        private int _Index;

        public ObjectReference(int index)
        {
            this._Index = index;
        }

        public int RawIndex
        {
            get => this._Index;
            set => this._Index = value;
        }

        public void Serialize(IUnrealSerializer serializer)
        {
            serializer.Serialize(ref _Index);
        }

        public int ImportIndex
        {
            get
            {
                if (this._Index < 0)
                {
                    return -this._Index - 1;
                }
                return -1;
            }
        }

        public int ExportIndex
        {
            get
            {
                if (this._Index > 0)
                {
                    return this._Index - 1;
                }
                return -1;
            }
        }

        public bool IsValid
        {
            get { return this._Index != 0; }
        }

        public override string ToString()
        {
            if (this._Index < 0)
            {
                return $"Import:{-this._Index - 1}";
            }

            if (this._Index > 0)
            {
                return $"Export:{this._Index - 1}";
            }

            return "None";
        }
    }
}
