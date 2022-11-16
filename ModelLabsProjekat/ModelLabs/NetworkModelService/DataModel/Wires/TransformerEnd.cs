using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class TransformerEnd : IdentifiedObject
    {

        private long ratioTapChanger = 0;

        private long terminal = 0;

        public TransformerEnd(long globalId) : base(globalId)
        {
        }

        public long RatioTapChanger
        {
            get
            {
                return this.ratioTapChanger;
            }
            set
            {
                this.ratioTapChanger = value;
            }
        }
        public long Terminal
        {
            get
            {
                return this.terminal;
            }
            set
            {
                this.terminal = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TransformerEnd x = (TransformerEnd)obj;
                return (x.Terminal == this.Terminal &&
                        x.RatioTapChanger == this.RatioTapChanger);
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
                case ModelCode.TRANSFORMER_END_TERMINAL:
                case ModelCode.TRANSFORMER_END_RADIO_TAP_CHARGER:
                    return true;

                default:
                    return base.HasProperty(cd);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TRANSFORMER_END_TERMINAL:
                    property.SetValue(terminal);
                    break;

                case ModelCode.TRANSFORMER_END_RADIO_TAP_CHARGER:
                    property.SetValue(ratioTapChanger);
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
                case ModelCode.TRANSFORMER_END_TERMINAL:
                    terminal = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
        public override bool IsReferenced
        {
            get
            {
                return ratioTapChanger != 0 || base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (refType == TypeOfReference.Reference || refType == TypeOfReference.Both)
            {
                if (terminal != 0)
                {
                    references[ModelCode.TRANSFORMER_END_TERMINAL] = new List<long>();
                    references[ModelCode.TRANSFORMER_END_TERMINAL].Add(terminal);
                }
                if (ratioTapChanger != 0)
                {
                    references[ModelCode.TRANSFORMER_END_RADIO_TAP_CHARGER] = new List<long>();
                    references[ModelCode.TRANSFORMER_END_RADIO_TAP_CHARGER].Add(ratioTapChanger);
                }
            }
            base.GetReferences(references, refType);
        }
        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.RATIO_TAP_CHANGER_TRANSFORMER_END:
                    ratioTapChanger = globalId;
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }

        }
        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TRANSFORMER_END_RADIO_TAP_CHARGER:

                    if (ratioTapChanger == GlobalId)
                    {
                        ratioTapChanger = 0;
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }
    }
}
