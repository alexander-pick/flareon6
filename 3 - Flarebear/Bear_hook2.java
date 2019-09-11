package com.example.bear_hook2;

import de.robv.android.xposed.IXposedHookLoadPackage;
import de.robv.android.xposed.XC_MethodHook;
import de.robv.android.xposed.XposedBridge;
import de.robv.android.xposed.XposedHelpers;
import de.robv.android.xposed.callbacks.XC_LoadPackage.LoadPackageParam;
import kotlin.text.StringsKt;

import static de.robv.android.xposed.XposedBridge.hookAllConstructors;
import static de.robv.android.xposed.XposedHelpers.findAndHookMethod;
import static de.robv.android.xposed.XposedHelpers.findClass;

public class Bear_hook2 implements IXposedHookLoadPackage {

    int f = 1;
    int p = 1;
    int c = 1;
    boolean isFound = false;

    public void handleLoadPackage(final LoadPackageParam lpparm) throws Throwable {

        String packageName = "com.fireeye.flarebear";
        String classToHook = "com.fireeye.flarebear.FlareBearActivity";

        //check if we are in the correct package
        if (!lpparm.packageName.equals(packageName))
            return;

        // get all methods
        /*Class<?> cclassToHook = findClass(classToHook, lpparm.classLoader);

        hookAllConstructors(cclassToHook, new XC_MethodHook() {
            protected void beforeHookedMethod(MethodHookParam param) throws Throwable {
                XposedBridge.log("Flarebear Hookall " + param.method.getName());
            }
        });

       findAndHookMethod(classToHook, lpparm.classLoader, "decrypt", new XC_MethodHook() {

            @Override
            protected void beforeHookedMethod(MethodHookParam param) throws Throwable {

                param.setResult(null);
                XposedBridge.log("Flarebear decrypt!");

                try {

                    //public final byte[] decrypt(@NotNull String str, @NotNull byte[] bArr)
                    String str = (String) param.args[2];
                    byte[] bArr = (byte[]) param.args[2];

                    XposedHelpers.callMethod(param.thisObject, "decrypt", str, bArr);

                    XposedBridge.log("Flarebear Param" + str);

                } catch (Exception e) {
                    return;
                }

                //isFound = true;
            }
        });*/

        // use setMood() to crack password
        findAndHookMethod(classToHook, lpparm.classLoader, "setMood", new XC_MethodHook() {

            @Override
            protected void beforeHookedMethod(MethodHookParam param) throws Throwable {

                XposedBridge.log("Flarebear setMood!");

                //this is very bad style but works, even with the division by zero :)

                isDone:
                for (int i = 0; i < 20; i++) {
                    f = i;
                    for (int i2 = 0; i2 < 20; i2++) {
                        p = i2;
                        for (int i3 = 0; i3 < 20; i3++) {
                            c = i3;
                            XposedBridge.log(Integer.toString(i) + Integer.toString(i2) + Integer.toString(i3));
                            XposedHelpers.callMethod(param.thisObject, "danceWithFlag");
                            if (isFound) {
                                break isDone;
                            }
                        }
                    }
                }

                param.setResult(null);

            }
        });

        // replace getPassword()
        findAndHookMethod(classToHook, lpparm.classLoader, "getPassword", new XC_MethodHook() {

            @Override
            protected void beforeHookedMethod(MethodHookParam param) throws Throwable {

                XposedBridge.log("Flarebear getPassword!");

                param.setResult("true");
                String str;
                int stat = f;
                int stat2 = p;
                int stat3 = c;
                String str2 = "*";
                String str3 = "&";
                String str4 = "@";
                String str5 = "#";
                String str6 = "+";
                String str7 = "$";
                String str8 = "_";
                String str9 = "";
                switch (stat % 9) {
                    case 0:
                        str = str8; // no
                        break;
                    case 1:
                        str = "-";
                        break;
                    case 2:
                        str = str7;
                        break;
                    case 3:
                        str = str6;
                        break;
                    case 4:
                        str = "!";
                        break;
                    case 5:
                        str = str5;
                        break;
                    case 6:
                        str = str4;
                        break;
                    case 7:
                        str = str3;
                        break;
                    case 8:
                        str = str2;
                        break;
                    default:
                        str = str9;
                        break;
                }
                switch (stat3 % 7) {
                    case 0:
                        str2 = str7;
                        break;
                    case 1:
                        str2 = str8;
                        break;
                    case 2:
                        str2 = str6;
                        break;
                    case 3:
                        str2 = str5;
                        break;
                    case 4:
                        str2 = str3;
                        break;
                    case 5:
                        break;
                    case 6:
                        str2 = str4;
                        break;
                    default:
                        str2 = str9;
                        break;
                }
                String repeat = StringsKt.repeat("flare", stat / stat3);

                String rotn = (String) XposedHelpers.callMethod(param.thisObject, "rotN", "bear", (stat * stat2));

                String repeat2 = StringsKt.repeat(rotn, stat2 * 2);
                String repeat3 = StringsKt.repeat("yeah", stat3);
                StringBuilder sb = new StringBuilder();
                sb.append(repeat);
                sb.append(str);
                sb.append(repeat2);
                sb.append(str2);
                sb.append(repeat3);
                param.setResult(sb.toString());
            }
        });

    }
}