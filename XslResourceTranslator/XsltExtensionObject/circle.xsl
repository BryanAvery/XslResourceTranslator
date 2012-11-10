<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:myResTran="urn:myResTran" xmlns:myObj="urn:myObj">
  <xsl:template match="data">
    <circles>
      <xsl:for-each select="circle">
        <circle>
          <xsl:copy-of select="node()"/>
          <circumference>
            <xsl:value-of select="myResTran:Find('Thecircumferenceis')"/>
            <xsl:value-of select="myObj:Circumference(radius)"/>
          </circumference>
        </circle>
      </xsl:for-each>
    </circles>
  </xsl:template>
</xsl:stylesheet>