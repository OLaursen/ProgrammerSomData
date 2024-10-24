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
    *sump = 0;
    for(i = 0 ; i < n ; i = i + 1) {
        *sump = *sump + arr[i];
    }   
}

void squares(int n, int arr[])
{
    int i;
    for (i = 0; i < n; i= i+1) {
        arr[i] = i * i;
    }
}