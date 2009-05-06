#!/usr/bin/sed -rf

# Translate any GL_FOO or CGL_FOO constants into GL.GL_FOO
s,value=\"(GL_.+)\",value=\"GL.\1\",g
s,value=\"CGL_(.+)\",value=\"GL.GL_\1\",g

# Translate COGL Pixel Format Masks from cogl-types.h
s,COGL_PIXEL_FORMAT_24,2,g
s,COGL_PIXEL_FORMAT_32,3,g
s,COGL_A_BIT,\(1 \&lt;\&lt; 4\),g
s,COGL_BGR_BIT,\(1 \&lt;\&lt; 5\),g
s,COGL_AFIRST_BIT,\(1 \&lt;\&lt; 6\),g
s,COGL_PREMULT_BIT,\(1 \&lt;\&lt; 7\),g
s,COGL_UNORDERED_MASK,0x0F,g
s,COGL_UNPREMULT_MASK,0x7F,g

# Translate some CoglPixelFormat C names to C#
s,(value=\".*)(COGL_PIXEL_FORMAT_RGBA_4444)(.*\"),\1Rgba4444\3,g
s,(value=\".*)(COGL_PIXEL_FORMAT_RGBA_5551)(.*\"),\1Rgba5551\3,g

# gapi-parser workaround where it translates:
#
#    COGL_PIXEL_FORMAT_RGB_888 = COGL_PIXEL_FORMAT_24
#
# to
#
#    Rgb888 = Two4
#

s,value=\"Two4\",value=\"2\",g
