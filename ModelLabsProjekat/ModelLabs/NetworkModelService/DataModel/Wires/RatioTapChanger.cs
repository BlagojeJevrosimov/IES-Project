using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class RatioTapChanger : TapChanger
    {

        private float stepVoltageIncrement;

        private TransformerControlMode tculControlMode;

        private long transformerEnd = 0;

        public RatioTapChanger(long globalId) : base(globalId)
        {
        }

        public virtual float StepVoltageIncrement
        {
            get
            {
                return this.stepVoltageIncrement;
            }
            set
            {
                this.stepVoltageIncrement = value;
            }
        }

        public virtual TransformerControlMode TculControlMode
        {
            get
            {
                return this.tculControlMode;
            }
            set
            {
                this.tculControlMode = value;
            }
        }
        public virtual long TransformerEnd
        {
            get
            {
                return this.transformerEnd;
            }
            set
            {
                this.transformerEnd = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                RatioTapChanger x = (RatioTapChanger)obj;
                return (
                    x.stepVoltageIncrement == this.stepVoltageIncrement &&
                    x.tculControlMode == this.tculControlMode &&
                    x.transformerEnd == this.transformerEnd);
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

        public override bool HasProperty(ModelCode cd)
        {
            switch (cd)
            {
                case ModelCode.RATIO_TAP_CHANGER_STEP_VOLTAGE_INCREMENT:
                case ModelCode.RATIO_TAP_CHANGER_TCUL_CONTROL_MODE:
                case ModelCode.RATIO_TAP_CHANGER_TRANSFORMER_END:
                    return true;

                default:
                    return base.HasProperty(cd);

            }
        }
        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.RATIO_TAP_CHANGER_STEP_VOLTAGE_INCREMENT:
                    property.SetValue(stepVoltageIncrement);
                    break;

                case ModelCode.RATIO_TAP_CHANGER_TCUL_CONTROL_MODE:
                    property.SetValue((short)tculControlMode);
                    break;

                case ModelCode.RATIO_TAP_CHANGER_TRANSFORMER_END:
                    property.SetValue(transformerEnd);
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
                case ModelCode.RATIO_TAP_CHANGER_STEP_VOLTAGE_INCREMENT:
                    stepVoltageIncrement = property.AsFloat();
                    break;

                case ModelCode.RATIO_TAP_CHANGER_TCUL_CONTROL_MODE:
                    tculControlMode = (TransformerControlMode)property.AsEnum();
                    break;
                case ModelCode.RATIO_TAP_CHANGER_TRANSFORMER_END:
                    transformerEnd = property.AsReference();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (transformerEnd != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.RATIO_TAP_CHANGER_TRANSFORMER_END] = new List<long>();
                references[ModelCode.RATIO_TAP_CHANGER_TRANSFORMER_END].Add(transformerEnd);
            }

            base.GetReferences(references, refType);
        }
    }
}
