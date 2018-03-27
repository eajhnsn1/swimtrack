var gulp = require("gulp"),
    fs = require("fs"),
    rename = require("gulp-rename"),
    minify = require("gulp-minify-css"),
    sass = require("gulp-sass"),
    merge = require("merge-stream")
    ;

gulp.task("copy", function () {
    var bs =  gulp.src("node_modules/bootstrap/dist/js/bootstrap.js")
        .pipe(gulp.dest("wwwroot/js"));

    var minbs = gulp.src("node_modules/bootstrap/dist/js/bootstrap.min.js")
        .pipe(gulp.dest("wwwroot/js"));

    return merge(bs, minbs);
});

gulp.task("sass", function () {
    return gulp.src('node_modules/bootstrap/scss/bootstrap.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css/bootstrap'))
        .pipe(minify())
        .pipe(rename({ suffix: ".min" }))
        .pipe(gulp.dest('wwwroot/css/bootstrap'))
});