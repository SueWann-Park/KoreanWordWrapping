string GetWrappedKoreanLine(string line)
{
    // KOREAN ONLY
    char[] k = line.ToCharArray();
    int count = 0;
    
    int ratio = 3; // Korean characters' width per other character's width, its average.
    int messagebox_numOfKorean = 22; // max number of Korean characters that can be printed in one line in the messagebox.
    int messageboxWidth = messagebox_numOfKorean * ratio - 1;
    
    for(int i = 0; i < line.Length; i++)
    {
        count += line[i] == ' ' || line[i] <= 122 ? 1 : ratio; // 122 measn ASCII code number of last english character.
        if(count >= messageboxWidth)
        {
            for(int j = i; j >= 0; j--) // bracktracing
            {
                if(line[j] == ' ')
                {
                    k[j] = '\n';
                    i = j;
                    break;
                }
            }
            count = 0;
        }
    }
    return new string(k);
}
