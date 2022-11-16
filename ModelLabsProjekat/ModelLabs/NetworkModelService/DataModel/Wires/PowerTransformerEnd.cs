using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PowerTransformerEnd : TransformerEnd
    {

        private float b;

        private float b0;

        private WindingConnection connectionKind;

        private float g;

        private float g0;

        private int phaseAngleClock;

        private float r;

        private float r0;

        private float ratedS;

        private float ratedU;

        private float x;

        private float x0;

        private long powerTransformer = 0;

        public PowerTransformerEnd(long globalId) : base(globalId)
        {
        }

        public float B
        {
            get
            {
                return this.b;
            }
            set
            {
                this.b = value;
            }
        }

        public float B0
        {
            get
            {
                return this.b0;
            }
            set
            {
                this.b0 = value;
            }
        }
        public WindingConnection ConnectionKind
        {
            get
            {
                return this.connectionKind;
            }
            set
            {
                this.connectionKind = value;
            }
        }
        public float G
        {
            get
            {
                return this.g;
            }
            set
            {
                this.g = value;
            }
        }
        public  float G0
        {
            get
            {
                return this.g0;
            }
            set
            {
                this.g0 = value;
            }
        }
        public  int PhaseAngleClock
        {
            get
            {
                return this.phaseAngleClock;
            }
            set
            {
                this.phaseAngleClock = value;
            }
        }

        public  long PowerTransformer
        {
            get
            {
                return this.powerTransformer;
            }
            set
            {
                this.powerTransformer = value;
            }
        }
        public  float R
        {
            get
            {
                return this.r;
            }
            set
            {
                this.r = value;
            }
        }
        public  float R0
        {
            get
            {
                return this.r0;
            }
            set
            {
                this.r0 = value;
            }
        }
        public  float RatedS
        {
            get
            {
                return this.ratedS;
            }
            set
            {
                this.ratedS = value;
            }
        }
        public  float RatedU
        {
            get
            {
                return this.ratedU;
            }
            set
            {
                this.ratedU = value;
            }
        }
        public  float X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public  float X0
        {
            get
            {
                return this.x0;
            }
            set
            {
                this.x0 = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PowerTransformerEnd x = (PowerTransformerEnd)obj;
                return (
                    x.b == this.b &&
                    x.b0 == this.b0 &&
                    x.connectionKind == this.connectionKind &&
                    x.g == this.g &&
                    x.g0 == this.g0 &&
                    x.phaseAngleClock == this.phaseAngleClock &&
                    x.r == this.r &&
                    x.r0 == this.r0 &&
                    x.ratedS == this.ratedS &&
                    x.ratedU == this.ratedU &&
                    x.x == this.x &&
                    x.x0 == this.x0 &&
                    x.powerTransformer == this.powerTransformer
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
                case ModelCode.POWER_TRANSFORMER_END_B:
                case ModelCode.POWER_TRANSFORMER_END_B0:
                case ModelCode.POWER_TRANSFORMER_END_CONNECTION_KIND:
                case ModelCode.POWER_TRANSFORMER_END_G:
                case ModelCode.POWER_TRANSFORMER_END_G0:
                case ModelCode.POWER_TRANSFORMER_END_PHASE_ANGLE_CLOCK:
                case ModelCode.POWER_TRANSFORMER_END_POWER_TRANSFORMER:
                case ModelCode.POWER_TRANSFORMER_END_R:
                case ModelCode.POWER_TRANSFORMER_END_R0:
                case ModelCode.POWER_TRANSFORMER_END_RATEDS:
                case ModelCode.POWER_TRANSFORMER_END_RATEDU:
                case ModelCode.POWER_TRANSFORMER_END_X:
                case ModelCode.POWER_TRANSFORMER_END_X0:
                    return true;

                default:
                    return base.HasProperty(cd);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.POWER_TRANSFORMER_END_B:
                    property.SetValue(b);
                    break;

                case ModelCode.POWER_TRANSFORMER_END_B0:
                    property.SetValue(b0);
                    break;

                case ModelCode.POWER_TRANSFORMER_END_CONNECTION_KIND:
                    property.SetValue((short)connectionKind);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_G:
                    property.SetValue(g);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_G0:
                    property.SetValue(g0);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_PHASE_ANGLE_CLOCK:
                    property.SetValue(phaseAngleClock);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_POWER_TRANSFORMER:
                    property.SetValue(powerTransformer);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_R:
                    property.SetValue(r);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_R0:
                    property.SetValue(r0);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_RATEDS:
                    property.SetValue(ratedS);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_RATEDU:
                    property.SetValue(ratedU);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_X:
                    property.SetValue(x);
                    break;
                case ModelCode.POWER_TRANSFORMER_END_X0:
                    property.SetValue(x0);
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
                case ModelCode.POWER_TRANSFORMER_END_B:
                    b = property.AsFloat();
                    break;

                case ModelCode.POWER_TRANSFORMER_END_B0:
                    b0 = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_CONNECTION_KIND:
                    connectionKind = (WindingConnection)property.AsEnum();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_G:
                    g = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_G0:
                    g0 = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_PHASE_ANGLE_CLOCK:
                    phaseAngleClock = property.AsInt();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_POWER_TRANSFORMER:
                    powerTransformer = property.AsReference();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_R:
                    r = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_R0:
                    r0 = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_RATEDS:
                    ratedS = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_RATEDU:
                    ratedU = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_X:
                    x = property.AsFloat();
                    break;
                case ModelCode.POWER_TRANSFORMER_END_X0:
                    x0 = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (refType == TypeOfReference.Reference || refType == TypeOfReference.Both)
            {
                if (powerTransformer != 0)
                {
                    references[ModelCode.POWER_TRANSFORMER_END_POWER_TRANSFORMER] = new List<long>();
                    references[ModelCode.POWER_TRANSFORMER_END_POWER_TRANSFORMER].Add(powerTransformer);
                }
            }
            base.GetReferences(references, refType);
        }
    }
}
