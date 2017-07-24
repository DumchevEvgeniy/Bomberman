using System;

class MapSize {
    private const Int32 minSize = 5;

	public static void AdjustmentSize(ref Int32 width, ref Int32 length) {
        AdjustmentSizeValue(ref width);
        AdjustmentSizeValue(ref length);
        if(width > length)
            Swap(ref width, ref length);
    }

    private static void Swap(ref Int32 firstValue, ref Int32 secondValue) {
        var temp = firstValue;
        firstValue = secondValue;
        secondValue = temp;
    }
    private static void AdjustmentSizeValue(ref Int32 sizeValue) {
        if(sizeValue < minSize)
            sizeValue = minSize;
        if(sizeValue % 2 == 0)
            sizeValue = sizeValue - 1;
    }
}
