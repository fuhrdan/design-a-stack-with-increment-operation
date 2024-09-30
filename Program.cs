//*****************************************************************************
//** 1381. Design a Stack With Increment Operation   leetcode                **
//*****************************************************************************



typedef struct {
    int* temp;
    int top;
    int maxSize;
} CustomStack;

CustomStack* customStackCreate(int maxSize) {
    CustomStack* obj = (CustomStack*)malloc(sizeof(CustomStack));
    obj->temp = (int*)malloc(maxSize * sizeof(int));
    for(int i = 0; i < maxSize; i++) {
        obj->temp[i] = -1;
    }
    obj->top = -1;
    obj->maxSize = maxSize;
    return obj;
}

void customStackPush(CustomStack* obj, int x) {
    if(obj->top != obj->maxSize - 1) {
        obj->temp[++(obj->top)] = x;
    }
}

int customStackPop(CustomStack* obj) {
    if(obj->top == -1) {
        return -1;
    }
    int out = obj->temp[obj->top];
    obj->temp[obj->top--] = -1;
    return out;
}

void customStackIncrement(CustomStack* obj, int k, int val) {
    int len = k > obj->maxSize ? obj->maxSize : k;
    for(int i = 0; i < len; i++) {
        obj->temp[i] += val;
    }
}

void customStackFree(CustomStack* obj) {
    free(obj->temp);
    free(obj);
}

/**
 * Your CustomStack struct will be instantiated and called as such:
 * CustomStack* obj = customStackCreate(maxSize);
 * customStackPush(obj, x);
 
 * int param_2 = customStackPop(obj);
 
 * customStackIncrement(obj, k, val);
 
 * customStackFree(obj);
*/