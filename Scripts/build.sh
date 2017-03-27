project="WavesOfLife"

echo "Attempting to build $project for Android"

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildTarget Android \
  -buildWindowsPlayer "$(pwd)/Build/Android/latest.apk" \
  -quit

echo 'Logs from build'
cat $(pwd)/unity.log


echo 'Attempting to zip builds'
zip -r $(pwd)/Build/Android.zip $(pwd)/Build/Android/