namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class CreateScenario : GeneratedMessageLite<CreateScenario, Builder>
    {
        private static readonly string[] _createScenarioFieldNames = new string[] { "game_type", "scenario" };
        private static readonly uint[] _createScenarioFieldTags = new uint[] { 0x10, 8 };
        private static readonly CreateScenario defaultInstance = new CreateScenario().MakeReadOnly();
        private int gameType_;
        public const int GameTypeFieldNumber = 2;
        private bool hasGameType;
        private bool hasScenario;
        private int memoizedSerializedSize = -1;
        private int scenario_;
        public const int ScenarioFieldNumber = 1;

        static CreateScenario()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private CreateScenario()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CreateScenario prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CreateScenario scenario = obj as CreateScenario;
            if (scenario == null)
            {
                return false;
            }
            if ((this.hasScenario != scenario.hasScenario) || (this.hasScenario && !this.scenario_.Equals(scenario.scenario_)))
            {
                return false;
            }
            return ((this.hasGameType == scenario.hasGameType) && (!this.hasGameType || this.gameType_.Equals(scenario.gameType_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasScenario)
            {
                hashCode ^= this.scenario_.GetHashCode();
            }
            if (this.hasGameType)
            {
                hashCode ^= this.gameType_.GetHashCode();
            }
            return hashCode;
        }

        private CreateScenario MakeReadOnly()
        {
            return this;
        }

        public static CreateScenario ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CreateScenario ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateScenario ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CreateScenario ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CreateScenario ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CreateScenario ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CreateScenario ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CreateScenario ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateScenario ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateScenario ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CreateScenario, Builder>.PrintField("scenario", this.hasScenario, this.scenario_, writer);
            GeneratedMessageLite<CreateScenario, Builder>.PrintField("game_type", this.hasGameType, this.gameType_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _createScenarioFieldNames;
            if (this.hasScenario)
            {
                output.WriteInt32(1, strArray[1], this.Scenario);
            }
            if (this.hasGameType)
            {
                output.WriteInt32(2, strArray[0], this.GameType);
            }
        }

        public static CreateScenario DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CreateScenario DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GameType
        {
            get
            {
                return this.gameType_;
            }
        }

        public bool HasGameType
        {
            get
            {
                return this.hasGameType;
            }
        }

        public bool HasScenario
        {
            get
            {
                return this.hasScenario;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasScenario)
                {
                    return false;
                }
                if (!this.hasGameType)
                {
                    return false;
                }
                return true;
            }
        }

        public int Scenario
        {
            get
            {
                return this.scenario_;
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
                    if (this.hasScenario)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Scenario);
                    }
                    if (this.hasGameType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.GameType);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CreateScenario ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<CreateScenario, CreateScenario.Builder>
        {
            private CreateScenario result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CreateScenario.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CreateScenario cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CreateScenario BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CreateScenario.Builder Clear()
            {
                this.result = CreateScenario.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CreateScenario.Builder ClearGameType()
            {
                this.PrepareBuilder();
                this.result.hasGameType = false;
                this.result.gameType_ = 0;
                return this;
            }

            public CreateScenario.Builder ClearScenario()
            {
                this.PrepareBuilder();
                this.result.hasScenario = false;
                this.result.scenario_ = 0;
                return this;
            }

            public override CreateScenario.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CreateScenario.Builder(this.result);
                }
                return new CreateScenario.Builder().MergeFrom(this.result);
            }

            public override CreateScenario.Builder MergeFrom(CreateScenario other)
            {
                if (other != CreateScenario.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasScenario)
                    {
                        this.Scenario = other.Scenario;
                    }
                    if (other.HasGameType)
                    {
                        this.GameType = other.GameType;
                    }
                }
                return this;
            }

            public override CreateScenario.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CreateScenario.Builder MergeFrom(IMessageLite other)
            {
                if (other is CreateScenario)
                {
                    return this.MergeFrom((CreateScenario) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CreateScenario.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CreateScenario._createScenarioFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CreateScenario._createScenarioFieldTags[index];
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

                        case 8:
                        {
                            this.result.hasScenario = input.ReadInt32(ref this.result.scenario_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasGameType = input.ReadInt32(ref this.result.gameType_);
                }
                return this;
            }

            private CreateScenario PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CreateScenario result = this.result;
                    this.result = new CreateScenario();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CreateScenario.Builder SetGameType(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameType = true;
                this.result.gameType_ = value;
                return this;
            }

            public CreateScenario.Builder SetScenario(int value)
            {
                this.PrepareBuilder();
                this.result.hasScenario = true;
                this.result.scenario_ = value;
                return this;
            }

            public override CreateScenario DefaultInstanceForType
            {
                get
                {
                    return CreateScenario.DefaultInstance;
                }
            }

            public int GameType
            {
                get
                {
                    return this.result.GameType;
                }
                set
                {
                    this.SetGameType(value);
                }
            }

            public bool HasGameType
            {
                get
                {
                    return this.result.hasGameType;
                }
            }

            public bool HasScenario
            {
                get
                {
                    return this.result.hasScenario;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CreateScenario MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Scenario
            {
                get
                {
                    return this.result.Scenario;
                }
                set
                {
                    this.SetScenario(value);
                }
            }

            protected override CreateScenario.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x9a
            }
        }
    }
}

