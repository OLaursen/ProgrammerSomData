void main(int input)
{
    int ns[7];
    int max;
    max = 3;
    int freq[4];
    
    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;
    
    histogram(input, ns, max, freq);
    int i;
    for(i = 0; i <max+1; i=i+1){
        print freq[i];
    }
}

void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    int j;
    for(i = 0; i < max+1; i = i + 1){
        freq[i] = 0;
    }

    for(i = 0; i < n; i = i + 1){
        j = ns[i];
        freq[j] = freq[j] + 1;
    }
    
} 