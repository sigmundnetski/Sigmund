namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Date : GeneratedMessageLite<Date, Builder>
    {
        private static readonly string[] _dateFieldNames = new string[] { "day", "hours", "min", "month", "sec", "year" };
        private static readonly uint[] _dateFieldTags = new uint[] { 0x18, 0x20, 40, 0x10, 0x30, 8 };
        private int day_;
        public const int DayFieldNumber = 3;
        private static readonly Date defaultInstance = new Date().MakeReadOnly();
        private bool hasDay;
        private bool hasHours;
        private bool hasMin;
        private bool hasMonth;
        private bool hasSec;
        private bool hasYear;
        private int hours_;
        public const int HoursFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private int min_;
        public const int MinFieldNumber = 5;
        private int month_;
        public const int MonthFieldNumber = 2;
        private int sec_;
        public const int SecFieldNumber = 6;
        private int year_;
        public const int YearFieldNumber = 1;

        static Date()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private Date()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Date prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Date date = obj as Date;
            if (date == null)
            {
                return false;
            }
            if ((this.hasYear != date.hasYear) || (this.hasYear && !this.year_.Equals(date.year_)))
            {
                return false;
            }
            if ((this.hasMonth != date.hasMonth) || (this.hasMonth && !this.month_.Equals(date.month_)))
            {
                return false;
            }
            if ((this.hasDay != date.hasDay) || (this.hasDay && !this.day_.Equals(date.day_)))
            {
                return false;
            }
            if ((this.hasHours != date.hasHours) || (this.hasHours && !this.hours_.Equals(date.hours_)))
            {
                return false;
            }
            if ((this.hasMin != date.hasMin) || (this.hasMin && !this.min_.Equals(date.min_)))
            {
                return false;
            }
            return ((this.hasSec == date.hasSec) && (!this.hasSec || this.sec_.Equals(date.sec_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasYear)
            {
                hashCode ^= this.year_.GetHashCode();
            }
            if (this.hasMonth)
            {
                hashCode ^= this.month_.GetHashCode();
            }
            if (this.hasDay)
            {
                hashCode ^= this.day_.GetHashCode();
            }
            if (this.hasHours)
            {
                hashCode ^= this.hours_.GetHashCode();
            }
            if (this.hasMin)
            {
                hashCode ^= this.min_.GetHashCode();
            }
            if (this.hasSec)
            {
                hashCode ^= this.sec_.GetHashCode();
            }
            return hashCode;
        }

        private Date MakeReadOnly()
        {
            return this;
        }

        public static Date ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Date ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Date ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Date ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Date ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Date ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Date ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Date ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Date ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Date ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Date, Builder>.PrintField("year", this.hasYear, this.year_, writer);
            GeneratedMessageLite<Date, Builder>.PrintField("month", this.hasMonth, this.month_, writer);
            GeneratedMessageLite<Date, Builder>.PrintField("day", this.hasDay, this.day_, writer);
            GeneratedMessageLite<Date, Builder>.PrintField("hours", this.hasHours, this.hours_, writer);
            GeneratedMessageLite<Date, Builder>.PrintField("min", this.hasMin, this.min_, writer);
            GeneratedMessageLite<Date, Builder>.PrintField("sec", this.hasSec, this.sec_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _dateFieldNames;
            if (this.hasYear)
            {
                output.WriteInt32(1, strArray[5], this.Year);
            }
            if (this.hasMonth)
            {
                output.WriteInt32(2, strArray[3], this.Month);
            }
            if (this.hasDay)
            {
                output.WriteInt32(3, strArray[0], this.Day);
            }
            if (this.hasHours)
            {
                output.WriteInt32(4, strArray[1], this.Hours);
            }
            if (this.hasMin)
            {
                output.WriteInt32(5, strArray[2], this.Min);
            }
            if (this.hasSec)
            {
                output.WriteInt32(6, strArray[4], this.Sec);
            }
        }

        public int Day
        {
            get
            {
                return this.day_;
            }
        }

        public static Date DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Date DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDay
        {
            get
            {
                return this.hasDay;
            }
        }

        public bool HasHours
        {
            get
            {
                return this.hasHours;
            }
        }

        public bool HasMin
        {
            get
            {
                return this.hasMin;
            }
        }

        public bool HasMonth
        {
            get
            {
                return this.hasMonth;
            }
        }

        public bool HasSec
        {
            get
            {
                return this.hasSec;
            }
        }

        public bool HasYear
        {
            get
            {
                return this.hasYear;
            }
        }

        public int Hours
        {
            get
            {
                return this.hours_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasYear)
                {
                    return false;
                }
                if (!this.hasMonth)
                {
                    return false;
                }
                if (!this.hasDay)
                {
                    return false;
                }
                if (!this.hasHours)
                {
                    return false;
                }
                if (!this.hasMin)
                {
                    return false;
                }
                if (!this.hasSec)
                {
                    return false;
                }
                return true;
            }
        }

        public int Min
        {
            get
            {
                return this.min_;
            }
        }

        public int Month
        {
            get
            {
                return this.month_;
            }
        }

        public int Sec
        {
            get
            {
                return this.sec_;
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
                    if (this.hasYear)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Year);
                    }
                    if (this.hasMonth)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Month);
                    }
                    if (this.hasDay)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Day);
                    }
                    if (this.hasHours)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Hours);
                    }
                    if (this.hasMin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Min);
                    }
                    if (this.hasSec)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(6, this.Sec);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Date ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Year
        {
            get
            {
                return this.year_;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Date, Date.Builder>
        {
            private Date result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Date.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Date cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Date BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Date.Builder Clear()
            {
                this.result = Date.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Date.Builder ClearDay()
            {
                this.PrepareBuilder();
                this.result.hasDay = false;
                this.result.day_ = 0;
                return this;
            }

            public Date.Builder ClearHours()
            {
                this.PrepareBuilder();
                this.result.hasHours = false;
                this.result.hours_ = 0;
                return this;
            }

            public Date.Builder ClearMin()
            {
                this.PrepareBuilder();
                this.result.hasMin = false;
                this.result.min_ = 0;
                return this;
            }

            public Date.Builder ClearMonth()
            {
                this.PrepareBuilder();
                this.result.hasMonth = false;
                this.result.month_ = 0;
                return this;
            }

            public Date.Builder ClearSec()
            {
                this.PrepareBuilder();
                this.result.hasSec = false;
                this.result.sec_ = 0;
                return this;
            }

            public Date.Builder ClearYear()
            {
                this.PrepareBuilder();
                this.result.hasYear = false;
                this.result.year_ = 0;
                return this;
            }

            public override Date.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Date.Builder(this.result);
                }
                return new Date.Builder().MergeFrom(this.result);
            }

            public override Date.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Date.Builder MergeFrom(IMessageLite other)
            {
                if (other is Date)
                {
                    return this.MergeFrom((Date) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Date.Builder MergeFrom(Date other)
            {
                if (other != Date.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasYear)
                    {
                        this.Year = other.Year;
                    }
                    if (other.HasMonth)
                    {
                        this.Month = other.Month;
                    }
                    if (other.HasDay)
                    {
                        this.Day = other.Day;
                    }
                    if (other.HasHours)
                    {
                        this.Hours = other.Hours;
                    }
                    if (other.HasMin)
                    {
                        this.Min = other.Min;
                    }
                    if (other.HasSec)
                    {
                        this.Sec = other.Sec;
                    }
                }
                return this;
            }

            public override Date.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Date._dateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Date._dateFieldTags[index];
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
                            this.result.hasYear = input.ReadInt32(ref this.result.year_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasMonth = input.ReadInt32(ref this.result.month_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasDay = input.ReadInt32(ref this.result.day_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasHours = input.ReadInt32(ref this.result.hours_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasMin = input.ReadInt32(ref this.result.min_);
                            continue;
                        }
                        case 0x30:
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
                    this.result.hasSec = input.ReadInt32(ref this.result.sec_);
                }
                return this;
            }

            private Date PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Date result = this.result;
                    this.result = new Date();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Date.Builder SetDay(int value)
            {
                this.PrepareBuilder();
                this.result.hasDay = true;
                this.result.day_ = value;
                return this;
            }

            public Date.Builder SetHours(int value)
            {
                this.PrepareBuilder();
                this.result.hasHours = true;
                this.result.hours_ = value;
                return this;
            }

            public Date.Builder SetMin(int value)
            {
                this.PrepareBuilder();
                this.result.hasMin = true;
                this.result.min_ = value;
                return this;
            }

            public Date.Builder SetMonth(int value)
            {
                this.PrepareBuilder();
                this.result.hasMonth = true;
                this.result.month_ = value;
                return this;
            }

            public Date.Builder SetSec(int value)
            {
                this.PrepareBuilder();
                this.result.hasSec = true;
                this.result.sec_ = value;
                return this;
            }

            public Date.Builder SetYear(int value)
            {
                this.PrepareBuilder();
                this.result.hasYear = true;
                this.result.year_ = value;
                return this;
            }

            public int Day
            {
                get
                {
                    return this.result.Day;
                }
                set
                {
                    this.SetDay(value);
                }
            }

            public override Date DefaultInstanceForType
            {
                get
                {
                    return Date.DefaultInstance;
                }
            }

            public bool HasDay
            {
                get
                {
                    return this.result.hasDay;
                }
            }

            public bool HasHours
            {
                get
                {
                    return this.result.hasHours;
                }
            }

            public bool HasMin
            {
                get
                {
                    return this.result.hasMin;
                }
            }

            public bool HasMonth
            {
                get
                {
                    return this.result.hasMonth;
                }
            }

            public bool HasSec
            {
                get
                {
                    return this.result.hasSec;
                }
            }

            public bool HasYear
            {
                get
                {
                    return this.result.hasYear;
                }
            }

            public int Hours
            {
                get
                {
                    return this.result.Hours;
                }
                set
                {
                    this.SetHours(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Date MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Min
            {
                get
                {
                    return this.result.Min;
                }
                set
                {
                    this.SetMin(value);
                }
            }

            public int Month
            {
                get
                {
                    return this.result.Month;
                }
                set
                {
                    this.SetMonth(value);
                }
            }

            public int Sec
            {
                get
                {
                    return this.result.Sec;
                }
                set
                {
                    this.SetSec(value);
                }
            }

            protected override Date.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Year
            {
                get
                {
                    return this.result.Year;
                }
                set
                {
                    this.SetYear(value);
                }
            }
        }
    }
}

