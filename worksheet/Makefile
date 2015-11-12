all : pdf

LATEX             = pdflatex -shell-escape
BIBTEX            = bibtex

MAIN              = master
BIB               = bib/sources.bib
TEXFILES          = $(wildcard *.tex)\
		    $(wildcard set/*.tex)\
		    $(wildcard analysis/*/*.tex)\
		    $(wildcard analysis/*/*/*.tex)\
		    $(wildcard analysis/*/*/*/*.tex)\
		    $(wildcard development/*/*.tex)\
		    $(wildcard development/*/*/*.tex)\
		    $(wildcard development/*/*/*/*.tex)\
		    $(wildcard implementation/*/*.tex)\
		    $(wildcard implementation/*/*/*.tex)\
		    $(wildcard implementation/*/*/*/*.tex)\
		    $(wildcard app/*.tex)\
		    $(wildcard tbl/*.tex)
IMAGES            = $(wildcard img/*)
EPSPDFFILES       = $(patsubst %.eps, %.pdf, $(wildcard img/*.eps))\
		    $(patsubst %.eps, %.pdf, $(wildcard development/img/*.eps))\
		    $(patsubst %.eps, %.pdf, $(wildcard implementation/img/*.eps))\
		    $(patsubst %.eps, %.pdf, $(wildcard analysis/img/*.eps))
BILAG             = $(wildcard app/*/*.tex)

pdf : $(MAIN).pdf 

local : 
	$(LATEX) masterlocal.tex

force : 
	$(LATEX) $(MAIN).tex
	$(BIBTEX) $(MAIN).aux
	$(LATEX) $(MAIN).tex
	$(LATEX) $(MAIN).tex

$(MAIN).pdf :  $(TEXFILES) $(IMAGES)\
	$(EPSPDFFILES) $(BILAG) $(BIB)
	$(LATEX) ${MAIN}
	if egrep -c "No file.*\.bbl|Citation.*undefined" $(MAIN).log;then\
		echo "** Running BibTeX **";\
		$(BIBTEX) $(MAIN).aux;\
		else echo "** No need to run BibTeX **";\
		fi
	@while ( grep "Rerun to get cross-references"\
		${MAIN}.log > /dev/null ); do\
		echo '** Re-running LaTeX **';\
		$(LATEX) ${MAIN};\
		done

clean :
	rm -f *.tdo
	rm -f *.nlo
	rm -f *.aux
	rm -f *.log
	rm -f *.bbl
	rm -f *.out
	rm -f *.bak
	rm -f *.blg
	rm -f *.toc
	rm -f *.lox
	rm -f *.auxlock
	rm -f *.fls
	rm -f *.upa
	rm -f *.upb
	rm -f *.lof
	rm -f *.fdb_latexmk
	rm -f img/*.bak
	rm -f *.tw

once : 
	$(LATEX) $(MAIN).tex

# EPS-FILES
%.pdf : %.eps
	epstopdf $*.eps
