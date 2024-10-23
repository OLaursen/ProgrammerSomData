void main(int input)
{
    int arr[20];
    int sump;
    squares(input, arr);
    arrsum(input, arr, &sump);
    print sump;
}

void arrsum (int n, int arr[], int *sump){
    int i;
    i = 0;
    *sump = 0;
    while (i < n-1) {
        i = i + 1;
        *sump = *sump + arr[i];
    }
}

void squares(int n, int arr[])
{
    int i;
    i = 0;
    while (i < n)
    {
        i = i + 1;
        arr[i] = i * i;
    }
}