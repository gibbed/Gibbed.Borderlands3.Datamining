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

namespace UnrealScriptFormats
{
    public struct Name : IUnrealSerializable, IEquatable<Name>, IEquatable<string>, IComparable<string>
    {
        public int Id;
        public uint Index;
        public string Value;

        public void Serialize(IUnrealSerializer serializer)
        {
            serializer.Serialize(ref this.Id);
            serializer.Serialize(ref this.Index);
            this.Value = serializer.LookupName(this);
        }

        public override string ToString()
        {
            return this.Value ?? $"Name[{this.Id}:{this.Index}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Name name)
            {
                return this.Equals(name);
            }

            if (obj is string str)
            {
                return Equals(str);
            }

            return false;
        }

        public bool Equals(Name other)
        {
            return this.Id == other.Id &&
                   this.Index == other.Index &&
                   this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hashCode = -1054019183;
            hashCode = hashCode * -1521134295 + this.Id.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Value);
            return hashCode;
        }

        public static bool operator ==(Name left, Name right)
        {
            return left.Equals(right) == true;
        }

        public static bool operator !=(Name left, Name right)
        {
            return left.Equals(right) == false;
        }

        public bool Equals(string other)
        {
            return this.Value.Equals(other);
        }

        public static bool operator ==(Name left, string right)
        {
            return left.Equals(right) == true;
        }

        public static bool operator !=(Name left, string right)
        {
            return left.Equals(right) == false;
        }

        public int CompareTo(string other)
        {
            return this.Value.CompareTo(other);
        }

        public static implicit operator string(Name name) => name.Value;
    }
}
