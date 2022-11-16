using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class TapChanger : PowerSystemResource
    {
        private int highStep;

        private float initialDelay;

        private int lowStep;

        private bool ltcFlag;

        private int neutralStep;

        private float neutralU;

        private int normalStep;

        private bool regulationStatus;

        private float subsequentDelay;

        public TapChanger(long globalId) : base(globalId)
        {
        }

        public  int HighStep
        {
            get
            {
                return this.highStep;
            }
            set
            {
                this.highStep = value;
            }
        }
        public  float InitialDelay
        {
            get
            {
                return this.initialDelay;
            }
            set
            {
                this.initialDelay = value;
            }
        }

        public  int LowStep
        {
            get
            {
                return this.lowStep;
            }
            set
            {
                this.lowStep = value;
            }
        }
        public  bool LtcFlag
        {
            get
            {
                return this.ltcFlag;
            }
            set
            {
                this.ltcFlag = value;
            }
        }

        public  int NeutralStep
        {
            get
            {
                return this.neutralStep;
            }
            set
            {
                this.neutralStep = value;
            }
        }

        public  float NeutralU
        {
            get
            {
                return this.neutralU;
            }
            set
            {
                this.neutralU = value;
            }
        }

        public  int NormalStep
        {
            get
            {
                return this.normalStep;
            }
            set
            {
                this.normalStep = value;
            }
        }

        public  bool RegulationStatus
        {
            get
            {
                return this.regulationStatus;
            }
            set
            {
                this.regulationStatus = value;
            }
        }

        public  float SubsequentDelay
        {
            get
            {
                return this.subsequentDelay;
            }
            set
            {
                this.subsequentDelay = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TapChanger x = (TapChanger)obj;
                return (
                    x.highStep == this.highStep &&
                    x.initialDelay == this.initialDelay &&
                    x.LowStep == this.LowStep &&
                    x.ltcFlag == this.ltcFlag &&
                    x.neutralStep == this.neutralStep &&
                    x.neutralU == this.neutralU &&
                    x.normalStep == this.normalStep &&
                    x.regulationStatus == this.regulationStatus &&
                    x.subsequentDelay == this.subsequentDelay);
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
                case ModelCode.TAP_CHANGER_HIGH_STEP:
                case ModelCode.TAP_CHANGER_INITIAL_DELAY:
                case ModelCode.TAP_CHANGER_LOW_STEP:
                case ModelCode.TAP_CHANGER_LTC_FLAG:
                case ModelCode.TAP_CHANGER_NEUTRAL_STEP:
                case ModelCode.TAP_CHANGER_NEUTRAL_U:
                case ModelCode.TAP_CHANGER_NORMAL_STEP:
                case ModelCode.TAP_CHANGER_REGULATION_STATUS:
                case ModelCode.TAP_CHANGER_SUBSEQUENT_DELAY:

                    return true;
                default:
                    return base.HasProperty(t);
            }
        }
        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.TAP_CHANGER_HIGH_STEP:
                    property.SetValue(highStep);
                    break;

                case ModelCode.TAP_CHANGER_INITIAL_DELAY:
                    property.SetValue(initialDelay);
                    break;

                case ModelCode.TAP_CHANGER_LOW_STEP:
                    property.SetValue(lowStep);
                    break;

                case ModelCode.TAP_CHANGER_LTC_FLAG:
                    property.SetValue(ltcFlag);
                    break;

                case ModelCode.TAP_CHANGER_NEUTRAL_STEP:
                    property.SetValue(neutralStep);
                    break;
                case ModelCode.TAP_CHANGER_NEUTRAL_U:
                    property.SetValue(neutralU);
                    break;
                case ModelCode.TAP_CHANGER_NORMAL_STEP:
                    property.SetValue(normalStep);
                    break;
                case ModelCode.TAP_CHANGER_REGULATION_STATUS:
                    property.SetValue(regulationStatus);
                    break;
                case ModelCode.TAP_CHANGER_SUBSEQUENT_DELAY:
                    property.SetValue(subsequentDelay);
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

                case ModelCode.TAP_CHANGER_HIGH_STEP:
                    highStep = property.AsInt();
                    break;

                case ModelCode.TAP_CHANGER_INITIAL_DELAY:
                    initialDelay = property.AsFloat();
                    break;

                case ModelCode.TAP_CHANGER_LOW_STEP:
                    lowStep = property.AsInt();
                    break;

                case ModelCode.TAP_CHANGER_LTC_FLAG:
                    ltcFlag = property.AsBool();
                    break;

                case ModelCode.TAP_CHANGER_NEUTRAL_STEP:
                    neutralStep = property.AsInt();
                    break;
                case ModelCode.TAP_CHANGER_NEUTRAL_U:
                    neutralU = property.AsFloat();
                    break;
                case ModelCode.TAP_CHANGER_NORMAL_STEP:
                    normalStep = property.AsInt();
                    break;
                case ModelCode.TAP_CHANGER_REGULATION_STATUS:
                    regulationStatus = property.AsBool();
                    break;
                case ModelCode.TAP_CHANGER_SUBSEQUENT_DELAY:
                    subsequentDelay = property.AsFloat();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }
    }
}
