//
//  XhsApiManager.mm
//  UnityFramework
//
//  Created by 晴天 on 2023/10/10.
//

#if __cplusplus
extern "C" {
#endif
    bool c_join_qq_group(const char* groupUin, const char* key){
        NSString * str_groupUin = [NSString stringWithUTF8String:groupUin];
        NSString * str_key = [NSString stringWithUTF8String:key];
        NSString *urlStr = [NSString stringWithFormat:@"mqqapi://card/show_pslcard?src_type=internal&version=1&uin=%@&key=%@&card_type=group&source=external&jump_from=webapi", str_groupUin,str_key];
        NSURL *url = [NSURL URLWithString:urlStr];
        if([[UIApplication sharedApplication] canOpenURL:url]){
            [[UIApplication sharedApplication] openURL:url];
            return YES;
        }
        else return NO;
    }
#if __cplusplus
}
#endif
