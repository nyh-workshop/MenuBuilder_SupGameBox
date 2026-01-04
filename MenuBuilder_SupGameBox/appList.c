#include "appList.h"

// Menu Item Properties:
// From registers $4100-$410A, $2012-$201A:
// Note: $4106.0 selects the horizontal/vertical scrolling!
// These properties are arranged in this format:
//            $2012, $2013, $2014, $2015, $2016, $2017, $2018, $201A...
// ...cont'd  $4100, $4105, $4106, $4107, $4108, $4109, $410A, $410B
const unsigned char appProperties_0[] = { 0x04, 0x05, 0x06, 0x07, 0x00, 0x02, 0x00, 0x00, 0x22, 0x00, 0x01, 0x00, 0x01, 0x00, 0x10, 0x02 };
const unsigned char* menuItemProperties[] = {
appProperties_0
};

// Reset vectors:
const unsigned char appRstVct_0[] = { 0xD0, 0xFF };
const unsigned char* resetVectors[] = {
appRstVct_0
};

// App titles:
const char emptyTitle[] = "                ";
const char appTitle_0[] = "FELIX THE CAT";
const char* appTitleList[] = {
appTitle_0
};
