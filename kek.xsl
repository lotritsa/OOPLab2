<?xml version ="1.0"?>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:template match="ElectronicArchive">
	<TABLE BORDER="5">
	 <TR>
      <xsl:for-each select="//course">
	   <TR>
		<TD>
		  <TABLE BORDER="1" WIDTH="1200">
		   <TR>
			<th style="width:10%;">
			  <p align="left">Course</p>
			</th>
			<th style =" width:90%;">
			  <p align="left">
				<xsl:value-of select ="@COURSE" />
			  </p>
			</th>
		  </TR>
		 </TABLE>
		</TD>
<xsl:for-each select="group">
<TR>
  <TD>
    <TABLE BORDER="5" WIDTH="1200"> 
      <TR>
		<th style="width: 10%;">
		  <p align="left">Type</p>
		</th>
		<th style="width:90%;">
		  <p align="left">
			<xsl:value-of select="@GROUP"/>
		  </p>
		</th>
	  </TR>
	</TABLE>
  </TD>
<xsl:for-each select="paperwork">
 <TR>
   <TD>
	 <TABLE BORDER="5" WIDTH="1200">
	   <TR>
		 <th style="width:10%;">
		   <p align="left">DateOfCreation</p>
		 </th>
		<th style="width:90%;">
		 <p align="left">
		   <xsl:value-of select="@DATEOFCREATION"/>
		 </p>
		</th>
	  </TR>
	<TR>
  <th style="width:10%;">
	<p align="left">Name</p>
</th>
<th style="width:90%;">
<p align="left">
<xsl:value-of select="@NAME"/>
</p>
</th>
</TR>
<TR>
<th style="width:10%;">
<p align="left">Author</p>
</th>
<th style="width:90%; ">
<p align="left">
<xsl:value-of select="@AUTHOR"/>
</p>
</th>
</TR>
<TR>
<th style="width: 10%; ">
<p align="left">Amount</p>
</th>
<th style="width:90%;">
<p align="left">
<xsl:value-of select="@AMOUNT"/>
</p>
</th>
</TR>
</TABLE>
</TD>
</TR>
</xsl:for-each>
</TR>
</xsl:for-each>
</TR>
</xsl:for-each>
</TR>
</TABLE>

 

</xsl:template>
</xsl:stylesheet>
 
