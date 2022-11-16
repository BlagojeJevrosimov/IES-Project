using System;
using System.Collections.Generic;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Equipment : PowerSystemResource
    {

        private bool aggregate;

        private bool normallyInService;

        public Equipment(long globalId) : base(globalId)
        {
        }

        public bool Aggregate
        {
            get
            {
                return aggregate;
            }
            set
            {
                this.aggregate = value;
            }
        }

        public bool NormallyInService
        {
            get
            {
                return this.normallyInService;
            }
            set
            {
                this.normallyInService = value;
            }
        }
        public override bool Equals(object x)
        {
            if (base.Equals(x))
            {
                Equipment e = (Equipment)x;
                return (e.aggregate == this.aggregate &&
                        e.normallyInService == this.normallyInService);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {

                case ModelCode.EQUIPMENT_AGGREGATE:
                case ModelCode.EQUIPMENT_NORMALLYINSERVICE:

                    return true;
                default:
                    return base.HasProperty(t);
            }
        }
        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.EQUIPMENT_AGGREGATE:
                    property.SetValue(aggregate);
                    break;

                case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
                    property.SetValue(normallyInService);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }
        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.EQUIPMENT_AGGREGATE:
                    aggregate = property.AsBool();
                    break;

                case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
                    normallyInService = property.AsBool();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
    }
}
