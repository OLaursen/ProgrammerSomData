
void main (int input) {
    int arr[4];
    int output;
    arr[0] = 7;
    arr[1] = 13;
    arr[2]= 9;
    arr[3]= 8;
    arrsum(input, arr, &output);
    print output;
}
void arrsum (int n, int arr[], int *sump){
    int i;
    
    *sump = 0;
    
    while (i < n-1) {
        i = i + 1;
        *sump = *sump + arr[i];
    }
}