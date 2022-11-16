using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PowerTransformer : ConductingEquipment
    {

        private string vectorGroup;
        private List<long> powerTransformerEnds = new List<long>();

        public PowerTransformer(long globalId) : base(globalId)
        {
        }

        public string VectorGroup
        {
            get
            {
                return this.vectorGroup;
            }
            set
            {
                this.vectorGroup = value;
            }
        }

        public List<long> PowerTransformerEnds { get => powerTransformerEnds; set => powerTransformerEnds = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PowerTransformer x = (PowerTransformer)obj;
                return (x.vectorGroup == this.vectorGroup &&
                        CompareHelper.CompareLists(x.PowerTransformerEnds, this.PowerTransformerEnds)
                        );
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
                case ModelCode.POWER_TRANSFORMER_VECTOR_GROUP:
                case ModelCode.POWER_TRANSFORMER_POWER_TRANSFORMER_ENDS:
                    return true;

                default:
                    return base.HasProperty(cd);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.POWER_TRANSFORMER_VECTOR_GROUP:
                    property.SetValue(vectorGroup);
                    break;
                case ModelCode.POWER_TRANSFORMER_POWER_TRANSFORMER_ENDS:
                    property.SetValue(powerTransformerEnds);
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
                case ModelCode.POWER_TRANSFORMER_VECTOR_GROUP:
                    VectorGroup = property.AsString();
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
                return powerTransformerEnds.Count != 0 && base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (powerTransformerEnds.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.POWER_TRANSFORMER_POWER_TRANSFORMER_ENDS] = powerTransformerEnds.GetRange(0, powerTransformerEnds.Count);
            }
            base.GetReferences(references, refType);
        }
        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.POWER_TRANSFORMER_END_POWER_TRANSFORMER:
                    powerTransformerEnds.Add(globalId);
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
                case ModelCode.POWER_TRANSFORMER_POWER_TRANSFORMER_ENDS:

                    if (powerTransformerEnds.Contains(globalId))
                    {
                        powerTransformerEnds.Remove(globalId);
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
