namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PowerHistoryEnd : GeneratedMessageLite<PowerHistoryEnd, Builder>
    {
        private static readonly string[] _powerHistoryEndFieldNames = new string[0];
        private static readonly uint[] _powerHistoryEndFieldTags = new uint[0];
        private static readonly PowerHistoryEnd defaultInstance = new PowerHistoryEnd().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static PowerHistoryEnd()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryEnd()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryEnd prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is PowerHistoryEnd);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private PowerHistoryEnd MakeReadOnly()
        {
            return this;
        }

        public static PowerHistoryEnd ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryEnd ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEnd ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryEndFieldNames;
        }

        public static PowerHistoryEnd DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryEnd DefaultInstanceForType
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
                return true;
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PowerHistoryEnd ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryEnd, PowerHistoryEnd.Builder>
        {
            private PowerHistoryEnd result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryEnd.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryEnd cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PowerHistoryEnd BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryEnd.Builder Clear()
            {
                this.result = PowerHistoryEnd.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override PowerHistoryEnd.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryEnd.Builder(this.result);
                }
                return new PowerHistoryEnd.Builder().MergeFrom(this.result);
            }

            public override PowerHistoryEnd.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryEnd.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryEnd)
                {
                    return this.MergeFrom((PowerHistoryEnd) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryEnd.Builder MergeFrom(PowerHistoryEnd other)
            {
                if (other != PowerHistoryEnd.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override PowerHistoryEnd.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryEnd._powerHistoryEndFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryEnd._powerHistoryEndFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private PowerHistoryEnd PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryEnd result = this.result;
                    this.result = new PowerHistoryEnd();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override PowerHistoryEnd DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryEnd.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PowerHistoryEnd MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PowerHistoryEnd.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

