using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using Boxinator_V2;

class VideoConverter {

    public async Task ConvertAsync(string videoFile, string outputFolder, IProgress<int> progress,
        CancellationToken cancellationToken, IProgress<string> status, IProgress<string> timeRemaining) {
        await Task.Run(() => {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            using (VideoFileReader reader = new VideoFileReader()) {
                reader.Open(videoFile);
                Logger.LogDebug("video");
                long totalFrames = reader.FrameCount;
                for (int i = 0; i < totalFrames; i++) {
                    cancellationToken.ThrowIfCancellationRequested();

                    using (Bitmap frame = reader.ReadVideoFrame()) {
                        string outputFile = Path.Combine(outputFolder, $"frame{i:D8}");
                        frame.Save(outputFile, ImageFormat.Jpeg);
                    }

                    // This part slows down the conversion process
                    double progressPercentage = (double) i / totalFrames * 100;
                    double timeElapsed = stopWatch.Elapsed.TotalSeconds;
                    double estimatedTime = (timeElapsed * 100) / progressPercentage - timeElapsed;

                    progress.Report((int) progressPercentage);
                    status.Report("Frame " + i + " of " + totalFrames.ToString());
                    if (i != 0)
                        timeRemaining.Report("Time remaining: " + TimeSpan.FromSeconds(estimatedTime).ToString(@"hh\:mm\:ss"));
                }
            
            }
        }, cancellationToken);
    }

}