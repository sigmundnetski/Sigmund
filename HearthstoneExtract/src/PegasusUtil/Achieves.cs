namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class Achieves : GeneratedMessageLite<Achieves, Builder>
    {
        private static readonly string[] _achievesFieldNames = new string[] { "list" };
        private static readonly uint[] _achievesFieldTags = new uint[] { 10 };
        private static readonly Achieves defaultInstance = new Achieves().MakeReadOnly();
        private PopsicleList<Achieve> list_ = new PopsicleList<Achieve>();
        public const int ListFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static Achieves()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private Achieves()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Achieves prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Achieves achieves = obj as Achieves;
            if (achieves == null)
            {
                return false;
            }
            if (this.list_.Count != achieves.list_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.list_.Count; i++)
            {
                if (!this.list_[i].Equals(achieves.list_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Achieve> enumerator = this.list_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Achieve current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        public Achieve GetList(int index)
        {
            return this.list_[index];
        }

        private Achieves MakeReadOnly()
        {
            this.list_.MakeReadOnly();
            return this;
        }

        public static Achieves ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Achieves ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Achieves ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Achieves ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Achieves ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Achieves ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Achieves ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Achieves ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Achieves ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Achieves ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Achieves, Builder>.PrintField<Achieve>("list", this.list_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _achievesFieldNames;
            if (this.list_.Count > 0)
            {
                output.WriteMessageArray<Achieve>(1, strArray[0], this.list_);
            }
        }

        public static Achieves DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Achieves DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<Achieve> enumerator = this.ListList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Achieve current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        public int ListCount
        {
            get
            {
                return this.list_.Count;
            }
        }

        public IList<Achieve> ListList
        {
            get
            {
                return this.list_;
            }
        }

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<Achieve> enumerator = this.ListList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Achieve current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Achieves ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Achieves, Achieves.Builder>
        {
            private Achieves result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Achieves.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Achieves cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Achieves.Builder AddList(Achieve value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_.Add(value);
                return this;
            }

            public Achieves.Builder AddList(Achieve.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_.Add(builderForValue.Build());
                return this;
            }

            public Achieves.Builder AddRangeList(IEnumerable<Achieve> values)
            {
                this.PrepareBuilder();
                this.result.list_.Add(values);
                return this;
            }

            public override Achieves BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Achieves.Builder Clear()
            {
                this.result = Achieves.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Achieves.Builder ClearList()
            {
                this.PrepareBuilder();
                this.result.list_.Clear();
                return this;
            }

            public override Achieves.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Achieves.Builder(this.result);
                }
                return new Achieves.Builder().MergeFrom(this.result);
            }

            public Achieve GetList(int index)
            {
                return this.result.GetList(index);
            }

            public override Achieves.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Achieves.Builder MergeFrom(IMessageLite other)
            {
                if (other is Achieves)
                {
                    return this.MergeFrom((Achieves) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Achieves.Builder MergeFrom(Achieves other)
            {
                if (other != Achieves.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.list_.Count != 0)
                    {
                        this.result.list_.Add(other.list_);
                    }
                }
                return this;
            }

            public override Achieves.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Achieves._achievesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Achieves._achievesFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 10:
                            break;

                        default:
                        {
                            if (WireFormat.IsEndGroupTag(num))
                            {
                                return this;
                            }
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    input.ReadMessageArray<Achieve>(num, str, this.result.list_, Achieve.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private Achieves PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Achieves result = this.result;
                    this.result = new Achieves();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Achieves.Builder SetList(int index, Achieve value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_[index] = value;
                return this;
            }

            public Achieves.Builder SetList(int index, Achieve.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_[index] = builderForValue.Build();
                return this;
            }

            public override Achieves DefaultInstanceForType
            {
                get
                {
                    return Achieves.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int ListCount
            {
                get
                {
                    return this.result.ListCount;
                }
            }

            public IPopsicleList<Achieve> ListList
            {
                get
                {
                    return this.PrepareBuilder().list_;
                }
            }

            protected override Achieves MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Achieves.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xfc
            }
        }
    }
}

