using DekigataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataSample
{
    public class SampleData
    {
        public KoshuEntity[] Koshus { get; }
        public MeasurementItemEntity[] MeasurementItems { get; }
        public MeasurementPointEntity[] MeasurementPoints { get; }
        public MeasurementValueEntity[] MeasurementValues { get; }

        public SampleData(string kojiId)
        {
            var koji = new KoshuEntity.KojiObject { Id = kojiId, Name = "トレーニング用工事" };
            Koshus = new[]
            {
                new KoshuEntity
                {
                    Id = $"{kojiId}_koshu-1",
                    Koji = koji,
                    Name = "法面整形工",
                    Shubetu = "盛土部",
                },
                new KoshuEntity
                {
                    Id = $"{kojiId}_koshu-2",
                    Koji = koji,
                    Name = "コンクリートブロック工",
                    Shubetu = "コンクリートブロック積",
                },
            };

            MeasurementItems = new[]
            {
                new MeasurementItemEntity
                {
                    Id = $"{kojiId}_koshu-1_item-1",
                    Koshu = ConvertItemKoshuObject(Koshus[0]),
                    Name = "高さ",
                    Mark = "h",
                    Unit = "m",
                    Degit = 3,
                    UnitOfDifference = "mm",
                    DegitOfDifference = 0,
                },
                new MeasurementItemEntity
                {
                    Id = $"{kojiId}_koshu-2_item-1",
                    Koshu = ConvertItemKoshuObject(Koshus[1]),
                    Name = "高さ",
                    Mark = "h",
                    Unit = "m",
                    Degit = 3,
                    UnitOfDifference = "mm",
                    DegitOfDifference = 0,
                },
                new MeasurementItemEntity
                {
                    Id = $"{kojiId}_koshu-2_item-2",
                    Koshu = ConvertItemKoshuObject(Koshus[1]),
                    Name = "幅",
                    Mark = "w",
                    Unit = "m",
                    Degit = 3,
                    UnitOfDifference = "mm",
                    DegitOfDifference = 0,
                },
            };

            MeasurementPoints = new[]
            {
                new MeasurementPointEntity
                {
                    Id = $"{kojiId}_koshu-1_point-1",
                    Index = 0,
                    Koshu = ConvertPointKoshuObject(Koshus[0]),
                    Name = "No.1",
                },
                new MeasurementPointEntity
                {
                    Id = $"{kojiId}_koshu-1_point-2",
                    Index = 1,
                    Koshu = ConvertPointKoshuObject(Koshus[0]),
                    Name = "No.2",
                },
                new MeasurementPointEntity
                {
                    Id = $"{kojiId}_koshu-2_point-1",
                    Index = 0,
                    Koshu = ConvertPointKoshuObject(Koshus[1]),
                    Name = "No.1",
                },
                new MeasurementPointEntity
                {
                    Id = $"{kojiId}_koshu-2_point-2",
                    Index = 1,
                    Koshu = ConvertPointKoshuObject(Koshus[1]),
                    Name = "No.2",
                },
            };

            MeasurementValues = new[]
            {
                new MeasurementValueEntity
                {
                    Id = $"{kojiId}_koshu-1_value-1",
                    Koshu = ConvertValueKoshuObject(Koshus[0]),
                    MeasurementItem = ConvertValueItemObject(MeasurementItems[0]),
                    Point = ConvertValuePointObject(MeasurementPoints[0]),
                    DesignValue = 10,
                    RuleValue = new MeasurementValueEntity.ToleranceObject
                    {
                        UpperLimit = 35,
                        LowerLimit = -35,
                        DisplayText = "±35",
                    },
                    Values = new []
                    {
                        new MeasurementValueEntity.MeasurementValueObject
                        {
                            Date = new DateTime(2022, 4, 5),
                            Actual = 10.008,
                            Difference = 8,
                        },
                    },
                },
                new MeasurementValueEntity
                {
                    Id = $"{kojiId}_koshu-1_value-2",
                    Koshu = ConvertValueKoshuObject(Koshus[0]),
                    MeasurementItem = ConvertValueItemObject(MeasurementItems[0]),
                    Point = ConvertValuePointObject(MeasurementPoints[1]),
                    DesignValue = 10,
                    RuleValue = new MeasurementValueEntity.ToleranceObject
                    {
                        UpperLimit = 35,
                        LowerLimit = -35,
                        DisplayText = "±35",
                    },
                    Values = new []
                    {
                        new MeasurementValueEntity.MeasurementValueObject
                        {
                            Date = new DateTime(2022, 4, 6),
                            Actual = 9.994,
                            Difference = -6,
                        },
                    },
                },
                new MeasurementValueEntity
                {
                    Id = $"{kojiId}_koshu-2_value-1",
                    Koshu = ConvertValueKoshuObject(Koshus[1]),
                    MeasurementItem = ConvertValueItemObject(MeasurementItems[0]),
                    Point = ConvertValuePointObject(MeasurementPoints[0]),
                    DesignValue = 3,
                    RuleValue = new MeasurementValueEntity.ToleranceObject
                    {
                        UpperLimit = 20,
                        LowerLimit = -20,
                        DisplayText = "±20",
                    },
                    Values = new []
                    {
                        new MeasurementValueEntity.MeasurementValueObject
                        {
                            Date = new DateTime(2022, 4, 10),
                            Actual = 3.024,
                            Difference = 24,
                        },
                    },
                },
                new MeasurementValueEntity
                {
                    Id = $"{kojiId}_koshu-2_value-2",
                    Koshu = ConvertValueKoshuObject(Koshus[1]),
                    MeasurementItem = ConvertValueItemObject(MeasurementItems[0]),
                    Point = ConvertValuePointObject(MeasurementPoints[1]),
                    DesignValue = 3,
                    RuleValue = new MeasurementValueEntity.ToleranceObject
                    {
                        UpperLimit = 20,
                        LowerLimit = -20,
                        DisplayText = "±20",
                    },
                    Values = new []
                    {
                        new MeasurementValueEntity.MeasurementValueObject
                        {
                            Date = new DateTime(2022, 4, 11),
                            Actual = 2.999,
                            Difference = -1,
                        },
                    },
                },
                new MeasurementValueEntity
                {
                    Id = $"{kojiId}_koshu-2_value-3",
                    Koshu = ConvertValueKoshuObject(Koshus[1]),
                    MeasurementItem = ConvertValueItemObject(MeasurementItems[1]),
                    Point = ConvertValuePointObject(MeasurementPoints[0]),
                    DesignValue = 5,
                    RuleValue = new MeasurementValueEntity.ToleranceObject
                    {
                        UpperLimit = 24,
                        LowerLimit = -24,
                        DisplayText = "±24",
                    },
                    Values = new []
                    {
                        new MeasurementValueEntity.MeasurementValueObject
                        {
                            Date = new DateTime(2022, 4, 12),
                            Actual = 4.985,
                            Difference = -15,
                        },
                    },
                },
                new MeasurementValueEntity
                {
                    Id = $"{kojiId}_koshu-2_value-4",
                    Koshu = ConvertValueKoshuObject(Koshus[1]),
                    MeasurementItem = ConvertValueItemObject(MeasurementItems[1]),
                    Point = ConvertValuePointObject(MeasurementPoints[1]),
                    DesignValue = 5,
                    RuleValue = new MeasurementValueEntity.ToleranceObject
                    {
                        UpperLimit = 24,
                        LowerLimit = -24,
                        DisplayText = "±24",
                    },
                    Values = new []
                    {
                        new MeasurementValueEntity.MeasurementValueObject
                        {
                            Date = new DateTime(2022, 4, 13),
                            Actual = 4.998,
                            Difference = -2,
                        },
                    },
                },
            };
        }

        private MeasurementItemEntity.KoshuObject ConvertItemKoshuObject(KoshuEntity koshu)
        {
            return new MeasurementItemEntity.KoshuObject
            {
                Id = koshu.Id,
                Name = koshu.Name,
                Shubetu = koshu.Shubetu,
                SketchFile = koshu.SketchFile,
            };
        }
        private MeasurementPointEntity.KoshuObject ConvertPointKoshuObject(KoshuEntity koshu)
        {
            return new MeasurementPointEntity.KoshuObject
            {
                Id = koshu.Id,
                Name = koshu.Name,
            };
        }
        private MeasurementValueEntity.KoshuObject ConvertValueKoshuObject(KoshuEntity koshu)
        {
            return new MeasurementValueEntity.KoshuObject
            {
                Id = koshu.Id,
                Name = koshu.Name,
                Shubetu = koshu.Shubetu,
                SketchFile = koshu.SketchFile,
            };
        }

        private MeasurementValueEntity.MeasurementItemObject ConvertValueItemObject(MeasurementItemEntity item)
        {
            return new MeasurementValueEntity.MeasurementItemObject
            {
                Id = item.Id,
                Name = item.Name,
                Mark = item.Mark,
                Unit = item.Unit,
                Degit = item.Degit,
                UnitOfDifference = item.UnitOfDifference,
                DegitOfDifference = item.DegitOfDifference,
            };
        }

        private MeasurementValueEntity.MeasurementPointObject ConvertValuePointObject(MeasurementPointEntity point)
        {
            return new MeasurementValueEntity.MeasurementPointObject
            {
                Id = point.Id,
                Name = point.Name,
                Index = point.Index,
            };
        }
    }
}
