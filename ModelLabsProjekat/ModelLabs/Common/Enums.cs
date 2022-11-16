using System;

namespace FTN.Common
{
    public enum PhaseCode : short
    {
        Unknown = 0x0,
        N = 0x1,
        C = 0x2,
        CN = 0x3,
        B = 0x4,
        BN = 0x5,
        BC = 0x6,
        BCN = 0x7,
        A = 0x8,
        AN = 0x9,
        AC = 0xA,
        ACN = 0xB,
        AB = 0xC,
        ABN = 0xD,
        ABC = 0xE,
        ABCN = 0xF
    }

    public enum TransformerControlMode : short
    {
        REACTIVE = 0,       //Reactive power flow control
        VOLT = 1        //Voltage control

    }

    public enum WindingConnection : short
    {
        A = 0,      //Autotransformer common winding
        D = 1,		// Delta
        I = 2,      //Independent winding, for single-phase connections
        Y = 3,      // Wye
        Yn = 4,     //Wye, with neutral brought out for grounding.
        Z = 5,      // ZigZag
        Zn = 6,		// ZigZag, with neutral brought out for grounding.
    }
}
