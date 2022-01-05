import java.lang.StringBuilder

fun function(i: Int) {
    var ii = i
    ii *= ii
    val s = "${i}の二条は${ii}です。"

    val ss: String = s

    val sb = StringBuilder()
    sb.append(s)
    sb.append(ss)
}